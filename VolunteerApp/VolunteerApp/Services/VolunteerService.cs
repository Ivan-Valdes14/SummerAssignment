using VolunteerApp.Data;

namespace VolunteerApp.Services
{
    public class VolunteerService : IVolunteerService
    {
        private readonly ApplicationDbContext _dbContext;
        public VolunteerService(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public List<Volunteer> SearchVolunteers(string lastName)
        {
            List<Volunteer> volunteers = _dbContext.Volunteers.Where(i => i.LastName == lastName).ToList();
            return volunteers;
        }

        public bool AddVolunteer(Volunteer volunteer)
        {
            try
            {
                _dbContext.Volunteers.Add(volunteer);
                _dbContext.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                return false;   
            }

        }

        public Volunteer GetVolunteer(int id)
        {
            Volunteer volunteer = _dbContext.Volunteers.Where(i => i.ID == id).FirstOrDefault();
            return volunteer;
        }

        public bool EditVolunteer(Volunteer volunteer)
        {
            try
            {
               Volunteer existingVolunteer = _dbContext.Volunteers.Where(_ => _.ID == volunteer.ID).FirstOrDefault();
               if(existingVolunteer != null)
                {
                    existingVolunteer.FirstName = volunteer.FirstName;
                    existingVolunteer.LastName = volunteer.LastName;
                    existingVolunteer.Status = volunteer.Status;
                    _dbContext.SaveChanges();

                }
               return true;
            }
            catch (Exception)
            {

                return false;
            }

        }
    }
}
