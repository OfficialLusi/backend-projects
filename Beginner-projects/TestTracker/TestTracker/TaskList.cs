using System.Reflection.Metadata.Ecma335;

namespace TestTracker;

public class TaskList(List<TaskProp> allTask, List<TaskProp> doneTask, List<TaskProp> notDoneTask, List<TaskProp> inProgressTask)
{
    private List<TaskProp> AllTask { get; set; } = allTask;
    private List<TaskProp> DoneTask { get; set; } = doneTask;
    private List<TaskProp> NotDoneTask { get; set; } = notDoneTask;
    private List<TaskProp> InProgressTask { get; set; } = inProgressTask;

    public List<TaskProp> ReturnAllTask() => AllTask;
    public List<TaskProp> ReturnDoneTask() => DoneTask;
    public List<TaskProp> ReturnNotDoneTask() => NotDoneTask;
    public List<TaskProp> ReturnInProgressTask() => InProgressTask;
}
