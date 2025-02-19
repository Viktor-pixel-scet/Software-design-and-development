using Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task_5
{
    public class CharacterDirector
    {
        private ICharacterBuilder builder;

        public CharacterDirector(ICharacterBuilder builder)
        {
            this.builder = builder;
        }

        public void ChangeBuilder(ICharacterBuilder builder)
        {
            this.builder = builder;
        }

        public void ConstructWarrior(string name)
        {
            builder.SetHeight(185)
                   .SetPhysique("Атлетична")
                   .SetBaseStats(18, 12, 8, 16)
                   .SetLevel(1)
                   .AddAbility("Потужний удар")
                   .AddAbility("Бойовий клич")
                   .AddPassiveSkill("Витривалість воїна")
                   .AddInventoryItem("Меч")
                   .AddInventoryItem("Щит")
                   .SetClothing("Важка броня");
        }

        public void ConstructMage(string name)
        {
            builder.SetHeight(175)
                   .SetPhysique("Струнка")
                   .SetBaseStats(8, 10, 18, 8)
                   .SetLevel(1)
                   .AddAbility("Вогняна куля")
                   .AddAbility("Магічний щит")
                   .AddPassiveSkill("Мудрість мага")
                   .AddInventoryItem("Посох")
                   .AddInventoryItem("Книга заклинань")
                   .SetClothing("Мантія мага");
        }

        public void ConstructRogue(string name)
        {
            builder.SetHeight(170)
                   .SetPhysique("Спритна")
                   .SetBaseStats(12, 18, 12, 10)
                   .SetLevel(1)
                   .AddAbility("Прихований удар")
                   .AddAbility("Ухилення")
                   .AddPassiveSkill("Спритність злодія")
                   .AddInventoryItem("Кинджали")
                   .AddInventoryItem("Відмички")
                   .SetClothing("Легка броня");
        }

        public void ConstructEliteCharacter(string characterClass)
        {
            switch (characterClass.ToLower())
            {
                case "warrior":
                    ConstructEliteWarrior();
                    break;
                case "mage":
                    ConstructEliteMage();
                    break;
                case "rogue":
                    ConstructEliteRogue();
                    break;
                default:
                    throw new ArgumentException("Невідомий клас персонажа");
            }
        }

        private void ConstructEliteWarrior()
        {
            builder.SetHeight(190)
                   .SetPhysique("Богатирська")
                   .SetBaseStats(25, 15, 10, 20)
                   .SetLevel(10)
                   .AddAbility("Руйнівний удар")
                   .AddAbility("Бойовий клич")
                   .AddAbility("Непохитна воля")
                   .AddPassiveSkill("Майстерність бою")
                   .AddPassiveSkill("Загартована сталь")
                   .AddInventoryItem("Легендарний меч")
                   .AddInventoryItem("Щит титана")
                   .SetClothing("Обладунки дракона");
        }

        private void ConstructEliteMage()
        {
            builder.SetHeight(175)
                   .SetPhysique("Містична")
                   .SetBaseStats(10, 12, 25, 10)
                   .SetLevel(10)
                   .AddAbility("Метеоритний дощ")
                   .AddAbility("Часовий бар'єр")
                   .AddAbility("Архімагія")
                   .AddPassiveSkill("Містична аура")
                   .AddPassiveSkill("Мудрість віків")
                   .AddInventoryItem("Посох архімага")
                   .AddInventoryItem("Древній фоліант")
                   .SetClothing("Шати архімага");
        }

        private void ConstructEliteRogue()
        {
            builder.SetHeight(170)
                   .SetPhysique("Акробатична")
                   .SetBaseStats(15, 25, 15, 12)
                   .SetLevel(10)
                   .AddAbility("Смертельний танець")
                   .AddAbility("Тіньовий крок")
                   .AddAbility("Отруйний клинок")
                   .AddPassiveSkill("Майстер маскування")
                   .AddPassiveSkill("Смертельна грація")
                   .AddInventoryItem("Парні клинки тіні")
                   .AddInventoryItem("Плащ невидимості")
                   .SetClothing("Обладунки нічного мисливця");
        }
    }
}
