using System;
using System.Collections.Generic;
using System.Linq;
using System.Speech.Synthesis;
using System.Text;

namespace ThemeTest.Source
{
    public static class SpeechHelper
    {
        private static SpeechSynthesizer _speechSynth = new SpeechSynthesizer { Rate = 2 };

        public static void Party()
        {
            _speechSynth.SpeakAsync("Party party party!");
        }

        public static void StopPartying()
        {
            _speechSynth.SpeakAsync("Time to stop partying!");
        }
    }
}
