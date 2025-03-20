using NotesWebApp.Shared.Models;
using System.Net.Http.Json;

namespace NotesWebApp.Shared.Services
{
    public class NoteService
    {
        private readonly HttpClient _httpClient;


        public NoteService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<Note>> GetNotesAsync()
        {
            return await _httpClient.GetFromJsonAsync<List<Note>>("api/notes");
        }

        public async Task AddNoteAsync(Note note)
        {
            var response = await _httpClient.PostAsJsonAsync("api/notes", note);
            response.EnsureSuccessStatusCode(); 

        }

        public async Task DeleteNoteAsync(int id)
        {
            var response = await _httpClient.DeleteAsync($"api/notes/{id}");
            response.EnsureSuccessStatusCode(); 
        }

        public async Task UpdateNoteAsync(Note note)
        {
            var response = await _httpClient.PutAsJsonAsync($"api/notes/{note.Id}", note);
            response.EnsureSuccessStatusCode(); 
        }



    }
}
