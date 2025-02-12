using Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace ClassLibrary
{
    public class Character
    {
        // Базові характеристики
        public int Height { get; set; }
        public string Physique { get; set; }
        public string HairColor { get; set; }
        public string EyeColor { get; set; }
        public string Clothing { get; set; }
        public bool IsHero { get; set; }

        // Бойові характеристики
        public int Health { get; set; } = 100;
        public int MaxHealth { get; set; } = 100;
        public int Attack { get; set; }
        public int Defense { get; set; }
        public string CharacterClass { get; set; }
        public string WeaponType { get; set; }
        public int Level { get; set; } = 1;
        public int Experience { get; set; } = 0;
        public int ExperienceToNextLevel { get; set; } = 100;

        // Додаткові характеристики
        public int Strength { get; set; } = 10;
        public int Agility { get; set; } = 10;
        public int Intelligence { get; set; } = 10;
        public int Stamina { get; set; } = 10;
        public double CriticalChance { get; set; } = 5.0;
        public double DodgeChance { get; set; } = 5.0;

        // Спеціальні здібності
        public List<string> Abilities { get; set; } = new List<string>();
        public List<string> PassiveSkills { get; set; } = new List<string>();
        public List<string> Inventory { get; set; } = new List<string>();
        public List<string> Deeds { get; set; } = new List<string>();
        public Dictionary<string, int> Stats { get; set; } = new Dictionary<string, int>();

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.AppendLine($"=== {(IsHero ? "Герой" : "Ворог")} ===");
            sb.AppendLine($"Клас: {CharacterClass} | Рівень: {Level}");
            sb.AppendLine($"Здоров'я: {Health}/{MaxHealth}");
            sb.AppendLine($"Атака: {Attack} | Захист: {Defense}");
            sb.AppendLine($"Зріст: {Height}см");
            sb.AppendLine($"Статура: {Physique}");
            sb.AppendLine($"Зброя: {WeaponType}");

            if (Abilities.Count > 0)
            {
                sb.AppendLine("\nЗдібності:");
                foreach (var ability in Abilities)
                    sb.AppendLine($"- {ability}");
            }

            if (PassiveSkills.Count > 0)
            {
                sb.AppendLine("\nПасивні навички:");
                foreach (var skill in PassiveSkills)
                    sb.AppendLine($"- {skill}");
            }

            return sb.ToString();
        }

        public void LevelUp()
        {
            Level++;
            MaxHealth += 10;
            Health = MaxHealth;
            Strength += 2;
            Agility += 2;
            Intelligence += 2;
            Stamina += 2;
            Attack += 5;
            Defense += 3;
            ExperienceToNextLevel = Level * 100;
        }
    }

    public abstract class AbstractBuilder : ICharacterBuilder
    {
        protected Character character;

        protected AbstractBuilder()
        {
            character = new Character();
        }

        public ICharacterBuilder SetHeight(int height)
        {
            if (height < 120 || height > 250)
                throw new ArgumentException("Зріст має бути між 120 та 250 см");
            character.Height = height;
            return this;
        }

        public ICharacterBuilder SetPhysique(string physique)
        {
            character.Physique = physique;
            return this;
        }

        public ICharacterBuilder SetHairColor(string hairColor)
        {
            character.HairColor = hairColor;
            return this;
        }

        public ICharacterBuilder SetEyeColor(string eyeColor)
        {
            character.EyeColor = eyeColor;
            return this;
        }

        public ICharacterBuilder SetClothing(string clothing)
        {
            character.Clothing = clothing;
            return this;
        }

        public ICharacterBuilder AddInventoryItem(string item)
        {
            character.Inventory.Add(item);
            return this;
        }

        public abstract ICharacterBuilder AddDeed(string deed);

        public ICharacterBuilder SetBaseStats(int strength, int agility, int intelligence, int stamina)
        {
            character.Strength = strength;
            character.Agility = agility;
            character.Intelligence = intelligence;
            character.Stamina = stamina;
            return this;
        }

        public ICharacterBuilder SetLevel(int level)
        {
            character.Level = level;
            character.MaxHealth = 100 + ((level - 1) * 10);
            character.Health = character.MaxHealth;
            character.ExperienceToNextLevel = level * 100;
            return this;
        }

        public ICharacterBuilder AddAbility(string ability)
        {
            character.Abilities.Add(ability);
            return this;
        }

        public ICharacterBuilder AddPassiveSkill(string skill)
        {
            character.PassiveSkills.Add(skill);
            return this;
        }

        public Character Build()
        {
            character.Attack = CalculateAttack();
            character.Defense = CalculateDefense();
            character.CriticalChance = CalculateCriticalChance();
            character.DodgeChance = CalculateDodgeChance();
            return character;
        }

        protected virtual int CalculateAttack()
        {
            return character.Strength * 2 + character.Level * 5;
        }

        protected virtual int CalculateDefense()
        {
            return character.Stamina * 2 + character.Level * 3;
        }

        protected virtual double CalculateCriticalChance()
        {
            return 5.0 + (character.Agility * 0.2);
        }

        protected virtual double CalculateDodgeChance()
        {
            return 5.0 + (character.Agility * 0.15);
        }
    }

    public class HeroBuilder : AbstractBuilder
    {
        public HeroBuilder()
        {
            character.IsHero = true;
        }

        public override ICharacterBuilder AddDeed(string deed)
        {
            character.Deeds.Add($"Героїчний вчинок: {deed}");
            return this;
        }

        protected override int CalculateAttack()
        {
            return base.CalculateAttack() + 10;
        }
    }

    public class EnemyBuilder : AbstractBuilder
    {
        public EnemyBuilder()
        {
            character.IsHero = false;
        }

        public override ICharacterBuilder AddDeed(string deed)
        {
            character.Deeds.Add($"Зла справа: {deed}");
            return this;
        }

        protected override int CalculateDefense()
        {
            return base.CalculateDefense() + 10;
        }
    }
}