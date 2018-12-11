using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Text;

namespace DaleranGames.TouchSupport
{
    public class TouchTester : MonoBehaviour
    {
        [SerializeField] TextMeshProUGUI text;

        bool touchSupport = false;
        bool multiTouch = false;
        bool pressureSupport = false;
        bool stylusSupported = false;
        

        string supportString = "";

        // Start is called before the first frame update
        void Start()
        {
            GetSupportStatus();
            supportString = GetSupportString();
        }

        // Update is called once per frame
        void Update()
        {
            text.text = supportString + "Number of Touches: "+Input.touchCount+System.Environment.NewLine+GetTouchStatus();
        }

        void GetSupportStatus()
        {
            touchSupport = Input.touchSupported;
            multiTouch = Input.multiTouchEnabled;
            pressureSupport = Input.touchPressureSupported;
            stylusSupported = Input.stylusTouchSupported;
            
        }

        string GetSupportString()
        {
            return "Touch Supported: " + touchSupport.ToString() + System.Environment.NewLine
                + "Multi Touch Supported: "+multiTouch.ToString() + System.Environment.NewLine
                + "Pressure Supported: "+pressureSupport.ToString() + System.Environment.NewLine
                + "Stylus Supported: " +stylusSupported.ToString() + System.Environment.NewLine;
        }

        string GetTouchStatus()
        {
            StringBuilder sb = new StringBuilder();
            for (int i=0; i<Input.touches.Length;i++)
            {
                sb.AppendLine(GetTouchString(Input.touches[i]));
            }
            return sb.ToString();
        }

        string GetTouchString(Touch touch)
        {
            return touch.fingerId + " " +touch.position.ToString() + " Change: " + touch.deltaPosition.ToString() + " Phase: "+touch.phase.ToString()+" Radius: "+touch.radius;
        }


    }

}
