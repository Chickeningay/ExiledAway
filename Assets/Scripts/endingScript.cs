using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class endingScript : MonoBehaviour
{
    public GameObject text;

    void Start()
    {
        // Expecting FINAL letter ids here: g3/g4/g5 and f3/f4/f5
        string gfEnd = PlayerPrefs.GetString("gfPath", "g3").ToLower().Trim();
        string fatherEnd = PlayerPrefs.GetString("fatherPath", "f3").ToLower().Trim();

        // Clamp to valid endings
        if (gfEnd != "g3" && gfEnd != "g4" && gfEnd != "g5") gfEnd = "g3";
        if (fatherEnd != "f3" && fatherEnd != "f4" && fatherEnd != "f5") fatherEnd = "f3";

        string key = gfEnd + "_" + fatherEnd;

        text.GetComponent<TMP_Text>().text = GetEndingText(key);
    }

    private string GetEndingText(string key)
    {
        switch (key)
        {
            // =========================
            // g3: respectful goodbye
            // g4: loyal/patient love
            // g5: bitter cutoff
            //
            // f3: father withdraws (consequences)
            // f4: cautious alliance / progress
            // f5: disowned / no contact
            // =========================

            // -------- g3 combos --------
            case "g3_f3":
                return
@"ENDING: The Quiet Rupture

She let you go with grace. He stepped back with cold clarity.
Your letters became two different funerals: one tender, one stern.

You survived by accepting loss instead of fighting it.
But you didn’t rebuild—only endured.

WHO YOU ARE:
A realist under pressure. You choose restraint, even when it costs you connection.
You don’t beg. You don’t break. You simply keep walking.";

            case "g3_f4":
                return
@"ENDING: Duty Over Longing

You released love without blame… and kept your head down long enough for help to reach you.
Her goodbye gave you peace. His guidance gave you a path.

You’ll remember what you lost, but you won’t be defined by it.

WHO YOU ARE:
Disciplined and emotionally mature.
You can mourn without spiraling—and you can follow a plan without becoming cruel.";

            case "g3_f5":
                return
@"ENDING: Orphaned in Exile

She closed the chapter gently.
He sealed it like a verdict: no name, no contact, no return.

You’re left with one mercy—clarity.
Nothing to chase. Nothing to prove. Just silence and the future you must invent.

WHO YOU ARE:
A solitary survivor.
You don’t cling to what’s gone, but you pay for that strength with loneliness.";

            // -------- g4 combos --------
            case "g4_f3":
                return
@"ENDING: Love Without Backing

She believes in you. She waits.
But your father refuses to intervene—and power doesn’t forgive without leverage.

Your heart has a home.
Your life has no shield.

WHO YOU ARE:
A romantic fighter.
You hold on to one true thing and let it keep you alive—even when the world won’t help.";

            case "g4_f4":
                return
@"ENDING: The Return Route

She stays. He strategizes.
One love keeps your spirit intact, one ally keeps you breathing long enough to matter again.

You didn’t just answer letters.
You built a bridge out of patience and choices.

WHO YOU ARE:
Steady, loyal, and careful.
You don’t win by shouting—you win by lasting.";

            case "g4_f5":
                return
@"ENDING: Chosen Family

She offers faith and a future.
Your father cuts you off completely.

So you make the hardest trade:
blood for belonging, legacy for love.

WHO YOU ARE:
Independent and values-driven.
You’d rather be disowned than controlled—and you commit to the people who commit to you.";

            // -------- g5 combos --------
            case "g5_f3":
                return
@"ENDING: Burned Bridges

She walked away angry. He walked away warning you.
Two doors closed, but one of them slammed hard enough to echo.

Now every step is yours alone—and every consequence too.

WHO YOU ARE:
Defensive, proud, and cornered.
You protect yourself first, even if it scorches everything around you.";

            case "g5_f4":
                return
@"ENDING: The Soldier’s Heart

Love collapsed into resentment.
But your father still plays the long game—supplies, caution, survival.

You lost warmth, kept structure.
Not a happy ending—just a livable one.

WHO YOU ARE:
Pragmatic under emotional stress.
When feelings fail, you fall back on discipline and routine to stay standing.";

            case "g5_f5":
                return
@"ENDING: Total Silence

She cut you off with anger.
He erased you with intent.

No comfort. No backup. No soft landing.
Only the weight of what your words became.

WHO YOU ARE:
A hard case forged by isolation.
Either you learn to change—or you become the exile they always claimed you were.";

            default:
                return
@"ENDING: Unknown

Something went wrong reading your paths.
Make sure gfPath is g3/g4/g5 and fatherPath is f3/f4/f5.";
        }
    }
}
