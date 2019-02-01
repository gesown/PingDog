using Realterm;
using System;

namespace PingDog.Factory
{
    class RealTerminal : IRealtermIntf
    {
        public int baud { get; set; }
        public bool BigEndian { get; set; }
        public string Caption { get; set; }
        public EnumCaptureMode Capture { get; set; }
        public bool CaptureAsHex { get; set; }
        public int CaptureCountForCallback { get; set; }
        public bool CaptureDirect { get; set; }
        public int CaptureEnd { get; set; }
        public EnumUnits CaptureEndUnits { get; set; }
        public string CaptureFile { get; set; }
        public int CaptureTimeLeft { get; }
        public int CharCount { get; set; }
        public int CharDelay { get; set; }
        public int CPS { get; set; }
        public int DataBits { get; set; }
        public int DisplayAs { get; set; }
        public bool DTR { get; set; }
        public int EchoBaud { get; set; }
        public int EchoDataBits { get; set; }
        public int EchoFlowControl { get; set; }
        public string EchoParity { get; set; }
        public string EchoPort { get; set; }
        public bool EchoPortOpen { get; set; }
        public int EchoStopBits { get; set; }
        public bool EnableCaptureCallbacks { get; set; }
        public bool EnableTimerCallbacks { get; set; }
        public int FlowControl { get; set; }
        public int FrameSize { get; set; }
        public bool HalfDuplex { get; set; }
        public bool HideControls { get; set; }
        public int LineDelay { get; set; }
        public bool LinefeedIsNewline { get; set; }
        public bool MonitorOn { get; set; }
        public string Parity { get; set; }
        public string Port { get; set; }
        public bool PortOpen { get; set; }
        public int Rows { get; set; }
        public bool RTS { get; set; }
        public bool Send { get; set; }
        public string SendFile { get; set; }
        public int SendFileDelay { get; set; }
        public int SendFileRepeats { get; set; }
        public int StopBits { get; set; }
        public int TimerPeriod { get; set; }
        public bool TrayIconActive { get; set; }
        public string Version { get; }
        public bool Visible { get; set; }
        public EnumWindowState WindowState { get; set; }

        public bool AddCannedSendString(string SendString, int ControlNum)
        {
            throw new NotImplementedException();
        }

        public void ClearTerminal()
        {
            throw new NotImplementedException();
        }

        public void Close()
        {
            throw new NotImplementedException();
        }

        public void DataTriggerSet(int Index, string StartString, string EndString, int PacketSIze, int Timeout, bool AutoEnable, bool IgnoreCase, bool IncludeStrings)
        {
            throw new NotImplementedException();
        }

        public void DisableDataTrigger(int Index = 1)
        {
            throw new NotImplementedException();
        }

        public double DiskFree(int Drive)
        {
            throw new NotImplementedException();
        }

        public double DiskSize(int Drive)
        {
            throw new NotImplementedException();
        }

        public void EnableDataTrigger(int Index = 1)
        {
            throw new NotImplementedException();
        }

        public void NewlineTerminal()
        {
            throw new NotImplementedException();
        }

        public void PutChar(byte C)
        {
            throw new NotImplementedException();
        }

        public void PutString(string S)
        {
            throw new NotImplementedException();
        }

        public bool SelectTabSheet(string TabCaption)
        {
            throw new NotImplementedException();
        }

        public void StartCapture()
        {
            throw new NotImplementedException();
        }

        public void StartCaptureAppend()
        {
            throw new NotImplementedException();
        }

        public void StopCapture()
        {
            throw new NotImplementedException();
        }

        public void TimeStamp(int Style, byte Delimiter = 44)
        {
            throw new NotImplementedException();
        }

        public string WaitforDataTrigger(int Timeout)
        {
            throw new NotImplementedException();
        }
    }
}
