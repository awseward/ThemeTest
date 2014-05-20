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
            Say("Party party party!");
        }

        public static void StopPartying()
        {
            Say("Time to stop partying!");
        }

        public static void Say(String message)
        {
            _speechSynth.SpeakAsync(message);
        }
    }
}
