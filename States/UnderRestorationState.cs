namespace Digital_Art_Kursoviy_Project.States
{
    public class UnderRestorationState : IArtworkState
    {
        public string StateName => "Restoration";
        public bool IsVisibleToPublic => false; 
        public string GetStatusMessage() => "На реставрації";
    }
}