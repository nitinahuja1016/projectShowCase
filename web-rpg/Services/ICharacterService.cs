namespace web_rpg.Services
{
    public interface ICharacterService
    {
        Character GetCharacterById(int Id);
        List<Character> GetAllCharacters();
        List<Character> AddCharacter(Character character);
    }
}
