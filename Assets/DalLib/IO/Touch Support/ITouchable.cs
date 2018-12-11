using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DaleranGames.TouchSupport
{
    public interface ITouchable
    {
        void Touch(Touch touch);
    }
}