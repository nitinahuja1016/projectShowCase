namespace web_rpg.Dtos.Weapon
{
    public class AddWeaponDto
    {
        public String Name { get; set; }=String.Empty;
        public int Damage { get; set; }
        public int CharacterId { get; set; }    
    }
}
