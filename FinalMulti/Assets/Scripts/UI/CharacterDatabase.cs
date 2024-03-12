using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class CharacterDatabase : ScriptableObject
{
   public CharacterSelector[] character;

   public int CharacterCount
   {
      get
      {
         return character.Length;
      }
   }

   public CharacterSelector GetCharacter(int index)
   {
      return character[index];
   }
}
