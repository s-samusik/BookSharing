using BookSharing.Data;
using System;

namespace BookSharing.Models
{
    public class Book
    {
        private readonly BookDto dto;

        #region Properties
        public int Id => dto.Id;
        public string Title
        {
            get => dto.Title;
            set
            {
                if (string.IsNullOrWhiteSpace(value)) throw new ArgumentException(nameof(Title));
                dto.Title = value.Trim();
            }
        }
        public string Description
        {
            get => dto.Description;
            set => dto.Description = value.Trim();
        }
        public Author Author
        {
            get => new Author(dto.Author);
            set
            {
                if (value == null) throw new ArgumentException(nameof(Author));
                dto.Author.Id = value.Id;
            }
        }
        public Genre Genre
        {
            get => new Genre(dto.Genre);
            set
            {
                if (value == null) throw new ArgumentException(nameof(Genre));
                dto.Genre.Id = value.Id;
            }
        }
        public Publisher Publisher
        {
            get => new Publisher(dto.Publisher);
            set
            {
                if (value == null) throw new ArgumentException(nameof(Publisher));
                dto.Publisher.Id = value.Id;
            }
        }
        #endregion

        internal Book(BookDto dto)
        {
            this.dto = dto;
        }

        public static class DtoFactory
        {
            public static BookDto Create(string title, string description, AuthorDto author, GenreDto genre, PublisherDto publisher)
            {
                #region Checking incoming parameters
                if (string.IsNullOrWhiteSpace(title)) throw new ArgumentException(nameof(title));
                if (author == null) throw new ArgumentNullException(nameof(author));
                if (genre == null) throw new ArgumentNullException(nameof(genre));
                if (publisher == null) throw new ArgumentNullException(nameof(publisher));
                #endregion

                return new BookDto
                {
                    Title = title,
                    Description = description,
                    Author = author,
                    Genre = genre,
                    Publisher = publisher
                };
            }
        }

        public static class Mapper
        {
            public static Book Map(BookDto dto) => new Book(dto);
            public static BookDto Map(Book domain) => domain.dto;
        }

    }
}
