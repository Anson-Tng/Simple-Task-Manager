using System;

namespace TaskManager
{
    [Serializable]
    public class Task
    {
        private int _taskId;
        private string _description;
        private bool _isCompleted;
        private DateTime _taskDate;

        public Task() { }

        public Task(int taskId, string description, bool isCompleted = false)
        {
            // Constructor
            _taskId = taskId;
            _description = description;
            _isCompleted = isCompleted;
            _taskDate = DateTime.Now;
        }

        public int TaskId
        {
            get
            {
                return _taskId;
            }
            set
            {
                if (value > 0)
                {
                    _taskId = value;
                }
            }
        }
        public string Description
        {
            get
            {
                return _description;
            }
            set
            {
                if (!string.IsNullOrEmpty(value))
                {
                    _description = value;
                }
            }
        }
        public bool IsCompleted
        {
            get
            {
                return _isCompleted;
            }
            set
            {
                _isCompleted = value;
            }
        }

        public DateTime TaskDate
        {
            get
            {
                return _taskDate;
            }
            set
            {
                _taskDate = value;
            }
        }

        public override string ToString()
        {
            return "\nID: " + _taskId + "\nDescription: " + _description + "\nStatus: " + _isCompleted + "Date addded: " + _taskDate;
        }
    }
}
