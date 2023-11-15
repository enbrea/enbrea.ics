#region ENBREA.ICS Copyright (C) 2023 STÜBER SYSTEMS GmbH
/*    
 *    ENBREA.ICS 
 *    
 *    Copyright (C) 2023 STÜBER SYSTEMS GmbH
 *
 *    Licensed under the MIT License, Version 2.0. 
 * 
 */
#endregion

using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace Enbrea.Ics
{
    /// <summary>
    /// A low level command line parser for the iCalendar data format as defined in https://datatracker.ietf.org/doc/html/rfc5545
    /// </summary>
    public class IcsContentLineParser
    {
        private const int _bufferSize = 1024;
        private readonly char[] _buffer;
        private readonly TextReader _textReader;
        private int _bufferEnd = 0;
        private int _bufferPosition = 0;
        private TokenizerState _currentState;
        private int _lineCount = 0;
        private TokenizerState _previousState;
        private IcsToken _token;
        private IcsTokenBuilder _tokenBuilder;

        /// <summary>
        /// Initializes a new instance of the <see cref="IcsContentLineParser"/> class.
        /// </summary>
        /// <param name="textReader">The text reader to be used.</param>
        public IcsContentLineParser(TextReader textReader)
        {
            _buffer = new char[_bufferSize];
            _currentState = TokenizerState.IsInName;
            _textReader = textReader;
            _token = null;
            _tokenBuilder = new IcsTokenBuilder(IcsTokenType.Name);
        }

        /// <summary>
        /// Possible categories of a character
        /// </summary>
        private enum CharCategory { IsOrdinary, IsWhitespace, IsQuote, IsSemicolon, IsEqualSign, IsColon, IsEndOfLine, IsEndOfFile }

        /// <summary>
        /// Possible states for the tokenizer
        /// </summary>
        private enum TokenizerState { IsInName, IsInParamName, IsSeekingForParamValue, IsInParamValue, IsInQuotedParamValue, IsAfterQuotedParamValue, IsInValue, IsEndOfLine }

        /// <summary>
        /// Possible workflow commands for the tokenizer
        /// </summary>
        private enum TokenizerWorkflow { IgnoreToken, ConsumeToken, Continue }

        /// <summary>
        /// Reads all command lines out of the iCalendar stream and gives back an enumerator for the 
        /// <see cref="IcsContentLine"/> instances.
        /// </summary>
        /// <typeparam name="IcsContentLine">The <see cref="IcsContentLine"/> object type</typeparam>
        /// <returns>An enumerator of <see cref="IcsContentLine"/> object instances</returns>
        public IEnumerable<IcsContentLine> Read()
        {
            var cl = new IcsContentLine();
            var pn = (string)null;
            do
            {
                if (NextToken())
                {
                    switch (_token.Type)
                    {
                        case IcsTokenType.Name:
                            cl.Name = _token.Value;
                            continue;
                        case IcsTokenType.Value:
                            cl.Value = _token.Value.UnEscape();
                            break;
                        case IcsTokenType.ParamName:
                            pn = _token.Value;
                            continue;
                        case IcsTokenType.ParamValue:
                            cl.SetParameter(pn, _token.Value.UnEscape());
                            continue;
                    }

                    UpdateTokenizerState(TokenizerState.IsInName);

                    yield return cl;

                    cl = new IcsContentLine();
                }
            }
            while (_currentState != TokenizerState.IsEndOfLine);
        }

        /// <summary>
        /// Reads all command lines out of the iCalendar stream and gives back an enumerator for the 
        /// <see cref="IcsContentLine"/> instances.
        /// </summary>
        /// <typeparam name="IcsCommandLine">The <see cref="IcsContentLine"/> object type</typeparam>
        /// <returns>An async enumerator of <see cref="IcsContentLine"/> object instances</returns>
        public async IAsyncEnumerable<IcsContentLine> ReadAsync()
        {
            var cl = new IcsContentLine();
            var pn = (string)null;
            do
            {
                if (await NextTokenAsync())
                {
                    switch (_token.Type)
                    {
                        case IcsTokenType.Name:
                            cl.Name = _token.Value;
                            continue;
                        case IcsTokenType.Value:
                            cl.Value = _token.Value.UnEscape();
                            break;
                        case IcsTokenType.ParamName:
                            pn = _token.Value;
                            continue;
                        case IcsTokenType.ParamValue:
                            cl.SetParameter(pn, _token.Value.UnEscape());
                            continue;
                    }

                    UpdateTokenizerState(TokenizerState.IsInName);

                    yield return cl;

                    cl = new IcsContentLine();
                }
            }
            while (_currentState != TokenizerState.IsEndOfLine);
        }

        /// <summary>
        /// Categorise a character.
        /// </summary>
        /// <param name="c">The character.</param>
        /// <returns>Category of the character.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private CharCategory Categorise(char c)
        {
            if (c == '\0')
            {
                return CharCategory.IsEndOfFile;
            }
            else if ((c == '\n') || (c == '\r'))
            {
                return CharCategory.IsEndOfLine;
            }
            else if (c == '"')
            {
                return CharCategory.IsQuote;
            }
            else if (c == ';')
            {
                return CharCategory.IsSemicolon;
            }
            else if (c == '=')
            {
                return CharCategory.IsEqualSign;
            }
            else if (c == ':')
            {
                return CharCategory.IsColon;
            }
            else if (char.IsWhiteSpace(c))
            {
                return CharCategory.IsWhitespace;
            }
            else
            {
                return CharCategory.IsOrdinary;
            }
        }

        /// <summary>
        /// Asks for the next character from the iCalendar source.
        /// </summary>
        /// <returns>The next character from the iCalendar source or EoF if nothing to read.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private char NextChar()
        {
            if (_bufferPosition >= _bufferEnd - 1)
            {
                _bufferEnd = _textReader.Read(_buffer, 0, _bufferSize);
                if (_bufferEnd > 0)
                {
                    _bufferPosition = 0;
                    return _buffer[_bufferPosition];
                }
                else
                {
                    return '\0';
                }
            }
            else
            {
                _bufferPosition++;
                return _buffer[_bufferPosition];
            }
        }

        /// <summary>
        /// Asks for the next character from the iCalendar source. 
        /// </summary>
        /// <returns>A task that represents the asynchronous operation. The value of the TResult
        /// parameter contains the next character from the iCalendar source or EoF if nothing to read.</returns>
        private async ValueTask<char> NextCharAsync()
        {
            if (_bufferPosition >= _bufferEnd - 1)
            {
                _bufferEnd = await _textReader.ReadAsync(_buffer, 0, _bufferSize);
                if (_bufferEnd > 0)
                {
                    _bufferPosition = 0;
                    return _buffer[_bufferPosition];
                }
                else
                {
                    return '\0';
                }
            }
            else
            {
                _bufferPosition++;
                return _buffer[_bufferPosition];
            }
        }

        /// <summary>
        /// Parses iCalendar source for next token.
        /// </summary>
        /// <returns>true if token could be read; otherwise false.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private bool NextToken()
        {
            while (true)
            {
                switch (Parse(NextChar()))
                {
                    case TokenizerWorkflow.IgnoreToken:
                        return false;
                    case TokenizerWorkflow.ConsumeToken:
                        return true;
                }
            }
        }

        /// <summary>
        /// Parses iCalendar source for next token.
        /// </summary>
        /// <returns>A task that represents the asynchronous operation. The value of the 
        /// TResult parameter is true if token could be read; otherwise false.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private async ValueTask<bool> NextTokenAsync()
        {
            while (true)
            {
                switch (Parse(await NextCharAsync()))
                {
                    case TokenizerWorkflow.IgnoreToken:
                        return false;
                    case TokenizerWorkflow.ConsumeToken:
                        return true;
                }
            }
        }

        /// <summary>
        /// Parses given character and updates internal state.
        /// </summary>
        /// <param name="c">The character</param>
        /// <returns>Next workflow</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private TokenizerWorkflow Parse(char c)
        {
            switch (_currentState)
            {
                case TokenizerState.IsInName:
                    {
                        switch (Categorise(c))
                        {
                            case CharCategory.IsEqualSign:
                                throw ThrowException($"Character {c} not allowed in command name.");
                            case CharCategory.IsSemicolon:
                                _token = _tokenBuilder.ToToken();
                                _tokenBuilder.Reset(IcsTokenType.ParamName);
                                UpdateTokenizerState(TokenizerState.IsInParamName);
                                return TokenizerWorkflow.ConsumeToken;
                            case CharCategory.IsColon:
                                _token = _tokenBuilder.ToToken();
                                _tokenBuilder.Reset(IcsTokenType.Value);
                                UpdateTokenizerState(TokenizerState.IsInValue);
                                return TokenizerWorkflow.ConsumeToken;
                            default:
                                _tokenBuilder.Append(char.ToUpper(c));
                                return TokenizerWorkflow.Continue;
                        }
                    }

                case TokenizerState.IsInParamName:
                    {
                        switch (Categorise(c))
                        {
                            case CharCategory.IsSemicolon:
                            case CharCategory.IsColon:
                                throw ThrowException($"Character {c} not allowed in param name.");
                            case CharCategory.IsEqualSign:
                                _token = _tokenBuilder.ToToken();
                                _tokenBuilder.Reset(IcsTokenType.ParamValue);
                                UpdateTokenizerState(TokenizerState.IsSeekingForParamValue);
                                return TokenizerWorkflow.ConsumeToken;
                            default:
                                _tokenBuilder.Append(char.ToUpper(c));
                                return TokenizerWorkflow.Continue;
                        }
                    }

                case TokenizerState.IsSeekingForParamValue:
                    {
                        switch (Categorise(c))
                        {
                            case CharCategory.IsSemicolon:
                            case CharCategory.IsColon:
                                throw ThrowException($"Character {c} not allowed in param value.");
                            case CharCategory.IsQuote:
                                UpdateTokenizerState(TokenizerState.IsInQuotedParamValue);
                                return TokenizerWorkflow.Continue;
                            default:
                                _tokenBuilder.Append(c);
                                UpdateTokenizerState(TokenizerState.IsInParamValue);
                                return TokenizerWorkflow.Continue;
                        }
                    }

                case TokenizerState.IsInParamValue:
                    {
                        switch (Categorise(c))
                        {
                            case CharCategory.IsSemicolon:
                                _token = _tokenBuilder.ToToken();
                                _tokenBuilder.Reset(IcsTokenType.ParamName);
                                UpdateTokenizerState(TokenizerState.IsInParamName);
                                return TokenizerWorkflow.ConsumeToken;
                            case CharCategory.IsColon:
                                _token = _tokenBuilder.ToToken();
                                _tokenBuilder.Reset(IcsTokenType.Value);
                                UpdateTokenizerState(TokenizerState.IsInValue);
                                return TokenizerWorkflow.ConsumeToken;
                            default:
                                _tokenBuilder.Append(c);
                                return TokenizerWorkflow.Continue;
                        }
                    }

                case TokenizerState.IsInQuotedParamValue:
                    {
                        switch (Categorise(c))
                        {
                            case CharCategory.IsQuote:
                                UpdateTokenizerState(TokenizerState.IsAfterQuotedParamValue);
                                return TokenizerWorkflow.Continue;
                            default:
                                _tokenBuilder.Append(c);
                                return TokenizerWorkflow.Continue;
                        }
                    }

                case TokenizerState.IsAfterQuotedParamValue:
                    {
                        switch (Categorise(c))
                        {
                            case CharCategory.IsSemicolon:
                                _token = _tokenBuilder.ToToken();
                                _tokenBuilder.Reset(IcsTokenType.ParamName);
                                UpdateTokenizerState(TokenizerState.IsInParamName);
                                return TokenizerWorkflow.ConsumeToken;
                            case CharCategory.IsColon:
                                _token = _tokenBuilder.ToToken();
                                _tokenBuilder.Reset(IcsTokenType.Value);
                                UpdateTokenizerState(TokenizerState.IsInValue);
                                return TokenizerWorkflow.ConsumeToken;
                            default:
                                throw ThrowException($"Character {c} not allowed after quoted param value.");
                        }
                    }

                case TokenizerState.IsInValue:
                    {
                        switch (Categorise(c))
                        {
                            case CharCategory.IsEndOfLine:
                                UpdateTokenizerState(TokenizerState.IsEndOfLine);
                                return TokenizerWorkflow.Continue;
                            case CharCategory.IsEndOfFile:
                                _token = _tokenBuilder.ToToken();
                                _tokenBuilder.Reset(IcsTokenType.Name);
                                UpdateTokenizerState(TokenizerState.IsEndOfLine);
                                return TokenizerWorkflow.ConsumeToken;
                            default:
                                _tokenBuilder.Append(c);
                                return TokenizerWorkflow.Continue;
                        }
                    }

                case TokenizerState.IsEndOfLine:
                    {
                        switch (Categorise(c))
                        {
                            case CharCategory.IsWhitespace:
                                UpdateTokenizerState(_previousState);
                                return TokenizerWorkflow.Continue;
                            case CharCategory.IsEndOfLine:
                                return TokenizerWorkflow.Continue;
                            case CharCategory.IsEndOfFile:
                                return TokenizerWorkflow.IgnoreToken;
                            default:
                                _token = _tokenBuilder.ToToken();
                                _tokenBuilder.Reset(IcsTokenType.Name);
                                UpdateTokenizerState(TokenizerState.IsInName);
                                Parse(c);
                                return TokenizerWorkflow.ConsumeToken;
                        }
                    }

            }
            return TokenizerWorkflow.Continue;
        }

        /// <summary>
        /// Creates a new parser exception.
        /// </summary>
        /// <param name="message">Exception message</param>
        /// <returns>The newly created Exception instance</returns>
        private Exception ThrowException(string message)
        {
            return new IcsContentLineParserException(_lineCount + 1, message);
        }

        /// <summary>
        /// Updates the tokenizer state
        /// </summary>
        /// <param name="newState">The new state</param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private void UpdateTokenizerState(TokenizerState newState)
        {
            _previousState = _currentState;
            _currentState = newState;
        }
    }
}
