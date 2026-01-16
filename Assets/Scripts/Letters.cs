
using System.Collections.Generic;
using UnityEngine;

public class Letters : MonoBehaviour
{
    [System.Serializable]
    public class Letter
    {
        public string id;

        [TextArea(6, 20)]
        public string text;

        [TextArea(4, 10)]
        public string prompt;

        public string nextOnTrue;
        public string nextOnFalse;

        public bool isEnding;
    }

    public List<Letter> letters = new List<Letter>();

    Dictionary<string, Letter> lookup;

    void Awake()
    {
        // ===== GIRLFRIEND PATH =====

        letters = new List<Letter>
        {
            new Letter {
                id = "g1",
                text =
@"You’ve been exiled for so long.
I told myself I could wait, that love was stronger than time, but time keeps moving even when people don’t.
I have to be honest with you. I met someone else. It does not mean that I do not care about you, it is because I am not strong enough to pass these times alone.
I don’t know what this makes us now. I hope my mail reaches you.
-Girlfriend",
                prompt =
@"Decide if the reply is emotionally sincere.
Return TRUE only if the response accepts her pain without blame and shows maturity.
Return FALSE if defensive, possessive, or guilt-inducing.",
                nextOnTrue = "g2",
                nextOnFalse = "g3",
                isEnding = false
            },

            new Letter {
                id = "g2",
                text =
@"I received what you sent.
I cannot see clearly. I don’t even know anymore. Are you still waiting for me, or am I holding on to something that only exists in my memory?
If you still love me, show me. Make me believe that you are the guy that I am in love with for too long. Something small would be enough. Food. Flowers. Anything that proves I still matter to you.
-Girlfriend",
                prompt =
@"Decide if the reply proves love through action.
Return TRUE only if a concrete effort or sacrifice is promised.
Return FALSE if the response is vague or purely emotional.
Be balanced and give at least 50% chance for both, don't be overly critical",
                nextOnTrue = "g4",
                nextOnFalse = "g5",
                isEnding = false
            },

            new Letter {
                id = "g3",
                text =
@"I understand.
Truly. Some things don’t end because of lack of love. They end because holding on becomes too painful. It is hurting both of us. 
I wish you a happy life. I hope you survive. I hope you find peace, wherever you are.
-Girlfriend",
                prompt =
@"Decide if the reply respects her decision.
Return TRUE only if the response lets her go without pleading.
Return FALSE otherwise.",
                isEnding = true
            },

            new Letter {
                id = "g4",
                text =
@"I love you.
No matter how far you are, no matter how broken this has made us, I still love you. Not as a memory, not as a promise. 
If you can endure this situation I will come for you. We will leave this behind together. Wait for me and our happily ever after.
-Girlfriend",
                prompt =
@"Decide if the reply reinforces patience and trust.
Return TRUE only if emotionally stable and committed.
Return FALSE if doubtful or desperate.",
                isEnding = true
            },

            new Letter {
                id = "g5",
                text =
@"I knew it. I meant nothing to you.
I don’t know why I kept writing. I wish I could have pretended the mails never reached me. This was a big mistake.
I won’t humiliate myself by waiting to who does not deserve. Do not to reach me ever again.",
                prompt =
@"Decide if the reply accepts fault and respects boundaries.
Return TRUE only if calm and accountable.
Return FALSE if arguing or begging.",
                isEnding = true
            },

            // ===== FATHER PATH =====

            new Letter {
                id = "f1",
                text =
@"My son, 
I don't know how this happened. Probably, there were enemies in the party.
They find it easier to dispose of people with exile.
Discipline will keep you alive longer than anger ever could.
-Father",
                prompt =
@"Decide if the reply shows discipline and restraint.
Return TRUE only if calm and controlled.
Return FALSE if emotional or accusatory.",
                nextOnTrue = "f2",
                nextOnFalse = "f3",
                isEnding = false
            },

            new Letter {
                id = "f2",
                text =
@"I have arranged for additional supplies to be sent your way.
Every favor comes with a cost.
Have you done anything that someone could use against you?
Write carefully.
-Father",
                prompt =
@"Decide if the reply is honest but careful.
Return TRUE only if truthful without oversharing.
Return FALSE if reckless or dishonest.",
                nextOnTrue = "f4",
                nextOnFalse = "f5",
                isEnding = false
            },

            new Letter {
                id = "f3",
                text =
@"I see.
If this is how you want to deal with things, I will not intervene further.
There will be consequences.
-Father",
                prompt =
@"Decide if the reply accepts responsibility.
Return TRUE only if mature and self-aware.
Return FALSE if defiant.",
                isEnding = true
            },

            new Letter {
                id = "f4",
                text =
@"It is dangerous here, but we are making progress.
You must keep your head down and stay alive.
Do not give them anything they can use.
-Father",
                prompt =
@"Decide if the reply shows strategic patience.
Return TRUE only if cautious and restrained.
Return FALSE if impatient or demanding.",
                isEnding = true
            },

            new Letter {
                id = "f5",
                text =
@"I will be direct.
I cannot be associated with you ever again.
Do not contact me.
-Father",
                prompt =
@"Decide if the reply preserves dignity.
Return TRUE only if accepting reality calmly.
Return FALSE if emotionally reactive.",
                isEnding = true
            }
        };

        lookup = new Dictionary<string, Letter>();
        foreach (var l in letters)
            lookup[l.id] = l;
    }

    public Letter Get(string id)
    {
        return lookup.ContainsKey(id) ? lookup[id] : null;
    }
}


