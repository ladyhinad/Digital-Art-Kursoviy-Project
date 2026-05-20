namespace Digital_Art_Kursoviy_Project.States
{
    public class OnDisplayState : IArtworkState
    {
        public string StateName => "OnDisplay";
        public bool IsVisibleToPublic => true; 
        public string GetStatusMessage() => "В експозиції";
    }
}