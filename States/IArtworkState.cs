namespace Digital_Art_Kursoviy_Project.States
{
    public interface IArtworkState
    {
        string StateName { get; } 
        bool IsVisibleToPublic { get; } 
        string GetStatusMessage(); 
    }
}