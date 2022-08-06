using VolunteerApp.Data;

namespace VolunteerApp.Services
{
    public interface IVolunteerService
    {
        List<Volunteer> SearchVolunteers(string lastName);
        public bool AddVolunteer(Volunteer volunteer);

        public Volunteer GetVolunteer(int id);

        public bool EditVolunteer(Volunteer volunteer);
    }
}   