using System;
using System.Collections.Generic;
using System.Text;

namespace JTPServer
{
    class Status
    {
        public Status()
        {
        }
        //statuscode 1-6
        private int _statusCode;
        //type or reason of status
        private string _statusType;

        public string StatusMessage { get; set; }
        //Why put 6 here? Here is where message is set to status message
        public Status(int statusCode = 6, string message = null)
        {
            this._statusCode = statusCode;
            this.StatusMessage = message;
            //this inputs 6 into method SetErrorType
            SetErrorType(this._statusCode);
        }

        public string getStatusType()
        {
            return this._statusType;
        }

        private void SetErrorType(int statuscode)
        {
            switch (statuscode)
            {
                case 1:
                    this._statusType = "Ok";
                    break;
                case 2:
                    this._statusType = "Created";
                    break;
                case 3:
                    this._statusType = "Updated";
                    break;
                case 4:
                    this._statusType = "Bad Request";
                    break;
                case 5:
                    this._statusType = "Not found";
                    break;
                case 6:
                    this._statusType = "Error";
                    break;
                default:
                    this._statusType = "Unknown status";
                    break;
            }
        }
        // this gets the status code from client
        public int GetStatusCode()
        {
            return this._statusCode;
        }
        // this set should be from the client side
        public void SetStatusCode(int statusCode = 6)
        {
            this._statusCode = statusCode;
            SetErrorType(statusCode);
        }
    }
}
