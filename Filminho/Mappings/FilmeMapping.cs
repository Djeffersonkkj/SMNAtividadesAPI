using Filminho.DTos;
using Filminho.Models;

namespace Filminho.Mappings;

public static class FilmeMapping
{
    public static FilmeDto ToFilmeDto(this Filme filme)
    {
        return new FilmeDto
        {
            Title = filme.Title,
            Year = filme.Year,
            Released = filme.Released,
            Runtime = filme.Runtime,
            Genre = filme.Genre,
            Director = filme.Director,
            Writer = filme.Writer,
            Country = filme.Country,
            imdbRating = filme.imdbRating
        };
    }

    public static Filme ToFilme(this FilmeDto filmeDto)
    {
        return new Filme
        {
            Title = filmeDto.Title,
            Year = filmeDto.Year,
            Released = filmeDto.Released,
            Runtime = filmeDto.Runtime,
            Genre = filmeDto.Genre,
            Director = filmeDto.Director,
            Writer = filmeDto.Writer,
            Country = filmeDto.Country,
            imdbRating = filmeDto.imdbRating
        };
    }
}
