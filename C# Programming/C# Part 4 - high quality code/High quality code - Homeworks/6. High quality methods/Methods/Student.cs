using System;

namespace Methods
{
    public class Student
    {
        /// <summary>
        /// Gets or sets the first name of the student.
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// Gets or sets the last name of the student.
        /// </summary>
        public string LastName { get; set; }

        /// <summary>
        /// Gets or sets the birth date of the student.
        /// </summary>
        public DateTime DateOfBirth { get; set; }

        /// <summary>
        /// Check if this student is older than other student.
        /// </summary>
        /// <param name="other">The other student.</param>
        /// <returns>True if this student is older, false otherwise.</returns>
        /// <exception cref="ArgumentNullexception">Other student is null -or-
        /// this student`s date of birth is null -or-
        /// other students date of birth is null.</exception>
        public bool IsOlderThan(Student other)
        {
            if (other == null)
            {
                throw new ArgumentNullException("other");
            }

            if (this.DateOfBirth == null)
            {
                throw new ArgumentNullException("DateOfBirth", "This student`s birth date is not set.");
            }

            if (other.DateOfBirth == null)
            {
                throw new ArgumentNullException("DateOfBirth", "Other student birth date is nor set.");
            }

            return this.DateOfBirth > other.DateOfBirth;
        }
    }
}
