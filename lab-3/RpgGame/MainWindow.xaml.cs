using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;

namespace RpgGame
{
    public partial class MainWindow : Window
    {
        private IHero currentHero;
        private ObservableCollection<string> equipmentList;

        public MainWindow()
        {
            InitializeComponent();
            equipmentList = new ObservableCollection<string>();
            EquipmentListBox.ItemsSource = equipmentList;
            HeroTypeComboBox.SelectedIndex = 0;
        }

        private void HeroTypeComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            equipmentList.Clear();
            switch (HeroTypeComboBox.SelectedIndex)
            {
                case 0:
                    currentHero = new Warrior();
                    break;
                case 1:
                    currentHero = new Mage();
                    break;
                case 2:
                    currentHero = new Paladin();
                    break;
            }
            UpdateStats();
        }

        private void AddSword_Click(object sender, RoutedEventArgs e)
        {
            currentHero = new Sword(currentHero);
            equipmentList.Add("Меч");
            UpdateStats();
        }

        private void AddStaff_Click(object sender, RoutedEventArgs e)
        {
            currentHero = new Staff(currentHero);
            equipmentList.Add("Посох");
            UpdateStats();
        }

        private void AddArmor_Click(object sender, RoutedEventArgs e)
        {
            currentHero = new Armor(currentHero);
            equipmentList.Add("Броня");
            UpdateStats();
        }

        private void AddShield_Click(object sender, RoutedEventArgs e)
        {
            currentHero = new Shield(currentHero);
            equipmentList.Add("Щит");
            UpdateStats();
        }

        private void AddMagicRing_Click(object sender, RoutedEventArgs e)
        {
            currentHero = new MagicRing(currentHero);
            equipmentList.Add("Магічний перстень");
            UpdateStats();
        }

        private void UpdateStats()
        {
            HeroDescriptionText.Text = $"Тип героя: {GetHeroTypeInUkrainian(currentHero.GetDescription())}";
            DamageText.Text = $"Атака: {currentHero.GetDamage()}";
            DefenseText.Text = $"Захист: {currentHero.GetDefense()}";
            MagicPowerText.Text = $"Магічна сила: {currentHero.GetMagicPower()}";
        }

        private string GetHeroTypeInUkrainian(string englishType)
        {
            switch (englishType)
            {
                case "Warrior":
                    return "Воїн";
                case "Mage":
                    return "Маг";
                case "Paladin":
                    return "Паладін";
                default:
                    return englishType;
            }
        }
    }
}
