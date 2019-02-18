using System;
using System.Diagnostics;

namespace RPiButtons
{
    class Cli
    {

        private Process _cmd;
        private bool _verbose;

        public Cli(bool verbose=false)
        {
            _cmd = new Process();
            _verbose = verbose;
            _cmd.StartInfo.FileName = "/bin/bash";
            _cmd.StartInfo.RedirectStandardInput = true;
            _cmd.StartInfo.RedirectStandardOutput = true;
            _cmd.StartInfo.CreateNoWindow = true;
            _cmd.StartInfo.UseShellExecute = false;
        }

        private string _ExecCmd(string cmd){
            _cmd.Start();
            _cmd.StandardInput.WriteLine(cmd);
            _cmd.StandardInput.Flush();
            _cmd.StandardInput.Close();
            _cmd.WaitForExit();
            return _cmd.StandardOutput.ReadToEnd();

        }
        public void MPCStop()
        {
            _ExecCmd("mpc stop -q");

            if ( _verbose ){
                Console.WriteLine("Pause");
            }
        }
        public void MPCStart()
        {
            _ExecCmd("mpc play -q");
            if ( _verbose ){
                Console.WriteLine("Play");
            }
        }
        public bool MPCIsPlaying()
        {
            var cmdOutput = _ExecCmd("mpc status");
            if ( cmdOutput.Contains("playing")) {
                return true;
            } else {
                return false;
            }

        }

        public void MPCToggle(){
            if( this.MPCIsPlaying() ) {
                this.MPCStop();
            } else {
                this.MPCStart();
            }
        }
    }
}
