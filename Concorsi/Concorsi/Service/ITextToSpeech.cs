using System;
using System.Collections.Generic;
using System.Text;

namespace Concorsi.Service
{
    public interface ITextToSpeech
    {
        void Speak(string text);
    }
}
