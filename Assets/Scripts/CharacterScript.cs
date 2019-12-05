using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterScript : MonoBehaviour
{
    [TextArea]
    public string[] text;

    NPCSpriteScript info;
    string name;

    // Start is called before the first frame update
    void Start()
    {
        info = GetComponentInChildren<NPCSpriteScript>();
        name = info.Name;

        if (info.name == "ISHA")
        {
            text = new string[12];
            text[0] = "ROBERTA: Present your alibi. ";
            text[1] = "ISHA: Are you kidding me with this ? ";
            text[2] = "ISHA: It's enough having to listen to your bullshit during the day. ";
            text[3] = "ISHA: You and Candy.";
            text[4] = "ISHA:'Oh, Isha, I bet you'd look so much better if you brushed your hair in the morning.'";
            text[5] = "ISHA: 'A bit of concealer would take care of your unfortunate complexion.'";
            text[6] = "ISHA: Why do you even care who did it ? ";
            text[7] = "ISHA: Grow up.";
            text[8] = "ISHA: I'm not helping you.";
            text[9] = "ISHA: I just want to go to sleep.";
            text[10] = "ROBERTA: Quaft said no one sleeps until someone fesses up.";
            text[11] = "ISHA: Fine.I was sleeping.Leave me alone.";
        }
        else if (info.name == "ZARA")
        {
            text = new string[11];
            text[0] = "ZARA: It's huge.";
            text[1] = "ROBERTA: Back at the scene of the crime ? ";
            text[2] = "ZARA: What? Oh. Hi, Roberta.No, I was just checking it out.";
            text[3] = "ROBERTA: Were you pacing the halls tonight? I heard someone walking around when I was trying to sleep.";
            text[4] = "ZARA: Yeah, that was me.";
            text[5] = "ROBERTA: Trying to figure out how to hide the evidence of what you'd done?";
            text[6] = "ZARA: Hardly. ";
            text[7] = "ROBERTA: Your behavior is awfully suspicious.";
            text[8] = "ZARA: What, because I was walking the halls like I do every night? ";
            text[9] = "ZARA: Did you ask Candy these types of questions? Or just me ? ";
            text[10] = "ZARA: Maybe you should ask her to come up with an alibi.She has been pretty pissy lately.";
        }
        else if (info.name == "CANDY")
        {
            text = new string[22];
            text[0] = "ROBERTA: Hey.";
            text[1] = "CANDY: Hey.Can you believe all this ? ";
            text[2] = "ROBERTA: Disgusting, right? I can't wait to find out who did it.";
            text[3] = "CANDY: Same. What's your plan?";
            text[4] = "ROBERTA: Well, right now I'm just collecting evidence and alibis. ";
            text[5] = "CANDY: Right.";
            text[6] = "ROBERTA: So, where were you tonight?";
            text[7] = "CANDY: Seriously? ";
            text[8] = "ROBERTA: Yeah.";
            text[9] = "CANDY: You ask everyone that?";
            text[10] = "ROBERTA: Yeah.";
            text[11] = "CANDY: Why bother? We both know it was Elikine.";
            text[12] = "ROBERTA: Why do you think it was her?";
            text[13] = "CANDY: You know me.I spend every Wednesday night on the patio with my trusty vape.";
            text[14] = "ROBERTA: Right.";
            text[15] = "CANDY: Well, tonight I was out there and Elikine jumped out the window.";
            text[16] = "ROBERTA: What? ";
            text[17] = "CANDY: Out onto the patio. Then she ran off into the field and disappeared.";
            text[18] = "ROBERTA: Weird.";
            text[19] = "CANDY: I know.";
            text[20] = "ROBERTA: So you were vaping tonight? That's all?";
            text[21] = "CANDY: Yep.";
        }
        else if (info.name == "HELEN")
        {
            text = new string[6];
            text[0] = "ROBERTA: You were responsible for cleaning the bathroom. ";
            text[1] = "HELEN: I was. I cleaned it at around 10.That's how I know it was Isha.";
            text[2] = "HELEN: She's always leaving her nail clippers in the bathroom. I told her off about it and asked her to clean up after herself. ";
            text[3] = "HELEN: I bet she did it because she was mad she can't trim her toenails wherever she wants. ";
            text[4] = "ROBERTA: I see. And you're certain the shower was clean when you left?";
            text[5] = "HELEN: Positive.I scrubbed it myself.";
        }
        else if (info.name == "CARLA")
        {
            text = new string[6];
            text[0] = "ROBERTA: You took an awfully long shower tonight before bed. ";
            text[1] = "CARLA: It's my new conditioner. You have to leave it in for 15 minutes. ";
            text[2] = "ROBERTA: Plenty of time for all kinds of business.";
            text[3] = "CARLA: Gross.";
            text[4] = "CARLA: Anyway, it couldn't have been me. I used the other shower.";
            text[5] = "CARLA: Maybe you should go talk to Helen.I didn't hear her come in last night. And did you notice she's completely dressed? Like she didn't go to sleep at all. ";
        }
        else if (info.name == "ELIKENE")
        {
            text = new string[11];
            text[0] = "ROBERTA: Sup Ellie.";
            text[1] = "ELIKINE: Elikine.";
            text[2] = "ROBERTA: Why'd you shit in the shower?";
            text[3] = "ELIKINE: I didn't.";
            text[4] = "ROBERTA: Right.";
            text[5] = "ELIKINE: I'm serious. Why does everyone always blame me for these things?";
            text[6] = "ROBERTA: You're always sneaking around and shit. ";
            text[7] = "ROBERTA: And then there's the _____.";
            text[8] = "ELIKINE: I wasn't even in town when that happened.";
            text[9] = "ROBERTA: Whatever. Where were you tonight?";
            text[10] = "ELIKINE: None of your business. ";
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
