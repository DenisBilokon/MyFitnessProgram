using System;

namespace Fitness.BL.Model
{
    [Serializable]
    public class Exercise
    {
        public DateTime Start { get; }
        public DateTime Finish { get; }
        public Activity Activity { get; }
        public User User { get; }

        public Exercise(DateTime start,DateTime finish, Activity activity, User user)
        {
            //TODO ПРоверка

            start = Start;
            finish = Finish;
            Activity = activity;
            User = user;
        }
    }
}
