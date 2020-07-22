using RunPath.Test.Core.Photos;
using System.Collections.Generic;

namespace RunPath.Test.Core.Albums
{
    public class Album
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public int UserId { get; set; }

        public List<Photo> Photos { get; set; }

        public Album()
            => Photos = new List<Photo>();

        public void AddPhotos(IEnumerable<Photo> photos)
            => Photos.AddRange(photos);
    }
}
