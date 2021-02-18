using System;

namespace EventsTest
{
    public class MathStuff
    {
        public event EventHandler<int> NotifyEvent;

        public void MathEquation(int a, int b){

            onNotifyEvent(a + b);
        }

        public virtual void onNotifyEvent(int returnValue){
            NotifyEvent?.Invoke(this, returnValue);
        }


    }
}