namespace Digital_Art_Kursoviy_Project.States
{
    public class ArchivedState : IArtworkState
    {
        public string StateName => "Archived";
        public bool IsVisibleToPublic => false; 
        public string GetStatusMessage() => "В архіві галереї";
    }
}