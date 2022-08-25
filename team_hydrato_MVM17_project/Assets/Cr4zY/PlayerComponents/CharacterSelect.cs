using UnityEngine;
using System.Collections.Generic;
public class CharacterSelect : MonoBehaviour
{
    private Character current;
    public Character CurrentCharacter { get { return current; } }
    private Dictionary<Character, bool> unlocks = new();
    private PIA actions;
    public void Init(PIA _a)
    {
        actions = _a;
        unlocks.Add(Character.BrokenHorn, true);
        unlocks.Add(Character.Scythe, true);
        unlocks.Add(Character.III, false);
        unlocks.Add(Character.IV, false);
        ChangeCharacter(Character.BrokenHorn);
    }

    public void ActivateCharacterActions(Character character)
    {

        actions.asset.FindActionMap(character.ToString()).Enable();

    }
    public void DeactivateCharacterActions(Character character)
    {

        actions.asset.FindActionMap(character.ToString()).Disable();

    }

    public void ChangeCharacter(bool next)
    {
        Character target = current;
        do
        {
            target = target switch
            {
                Character.BrokenHorn => next ? Character.Scythe : Character.IV,
                Character.Scythe => next ? Character.III : Character.BrokenHorn,
                Character.III => next ? Character.IV : Character.Scythe,
                Character.IV => next ? Character.BrokenHorn : Character.III,
                _ => Character.BrokenHorn
            };
        }
        while (!unlocks[target]);

        ChangeCharacter(target);
    }
    private void ChangeCharacter(Character target)
    {
        if (current != Character.None)
        {
            DeactivateCharacterActions(current);
        }
        current = target;
        ActivateCharacterActions(current);
    }

    public void UnlockCharacter(Character target)
    {
        unlocks[target] = true;
    }

    public void LockCharacter(Character target)
    {
        unlocks[target] = false;
    }

}

