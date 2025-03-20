using API.DTOs;
using DAL.DbEntities;

namespace API.Mappers;

// Думаю, можно было и через автомаппер сделать..
public static class NoteMapper
{
    public static NoteDTO ToDto(Note note)
    {
        return new NoteDTO
        {
            Id = note.Id,
            Title = note.Title,
            Content = note.Content,
            CreatedAt = note.CreatedAt
        };
    }
}

