﻿using System;
using System.Collections.Generic;

namespace TextReplace
{

    class Idle : IState
    {
        private Idle()
        { }

        private static Idle _instance;
        public static Idle Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new Idle();
                }
                return _instance;
            }
        }

        #region IState Members

        public void Enter(IEntity entity)
        {
            //TODO: code to do something as we enter this state
            //Helper.InfoMessageBox("Entering the  Idle state" );
        }

        public void Execute(IEntity entity)
        {

            //TODO: code to do actions while we are in this state
            BlockDetails bd = entity as BlockDetails;
            //Helper.InfoMessageBox("Entering the  Idle state from " + bd.PreviousState.ToString());
            try
            {
                bd.CriticalError = 0;
                bd.DwgCounter = 0;
                bd.ChangeState(ReplaceBodyText.Instance);


            }
            catch (Exception ex)
            {
                bd.DidItOk = false;
                bd.ErrorMessage = ex.ToString();
                bd.CriticalError = 2;
                bd.ChangeState(ErrorState.Instance);
            }



        }

        public void Exit(IEntity entity)
        {

            //TODO: code to do something as we exit this state
            //Console.WriteLine ("Exiting the  Idle state");
        }

        #endregion
    }


}
