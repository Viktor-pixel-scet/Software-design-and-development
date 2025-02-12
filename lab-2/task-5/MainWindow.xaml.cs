using System;
using System.Windows;
using System.Windows.Media.Imaging;
using System.Windows.Media;
using System.Windows.Controls;
using System.Windows.Threading;
using ClassLibrary;
using System.Windows.Shapes;
using System.Text;
using System.Windows.Media.Animation;
using System.Windows.Media.Effects;

namespace task_5
{
    public partial class MainWindow : Window
    {
        private Character hero;
        private Character enemy;
        private Random random = new Random();
        private DispatcherTimer battleTimer;
        private bool isBattleActive = false;
        private StringBuilder battleLog = new StringBuilder();
        private bool isDefending = false;
        private const double DEFENSE_DAMAGE_REDUCTION = 0.5;
        private const double DEFENSE_COUNTER_DAMAGE = 0.3;

        public MainWindow()
        {
            InitializeComponent();
            InitializeDefaultImages();
            SetupBattleTimer();
            InitializeComboBoxes();
        }

        private void InitializeComboBoxes()
        {
            HeroHeight.Text = "180";
            EnemyHeight.Text = "200";
            HeroAttack.Text = "50";
            HeroDefense.Text = "30";
            EnemyAttack.Text = "45";
            EnemyDefense.Text = "35";

            // Виділити перші елементи у комбінованих вікнах
            if (HeroClass.Items.Count > 0) HeroClass.SelectedIndex = 0;
            if (HeroWeapon.Items.Count > 0) HeroWeapon.SelectedIndex = 0;
            if (HeroPhysique.Items.Count > 0) HeroPhysique.SelectedIndex = 0;
            if (HeroHairColor.Items.Count > 0) HeroHairColor.SelectedIndex = 0;
            if (HeroEyeColor.Items.Count > 0) HeroEyeColor.SelectedIndex = 0;
            if (HeroClothing.Items.Count > 0) HeroClothing.SelectedIndex = 0;

            if (EnemyClass.Items.Count > 0) EnemyClass.SelectedIndex = 0;
            if (EnemyWeapon.Items.Count > 0) EnemyWeapon.SelectedIndex = 0;
            if (EnemyPhysique.Items.Count > 0) EnemyPhysique.SelectedIndex = 0;
            if (EnemyHairColor.Items.Count > 0) EnemyHairColor.SelectedIndex = 0;
            if (EnemyEyeColor.Items.Count > 0) EnemyEyeColor.SelectedIndex = 0;
            if (EnemyClothing.Items.Count > 0) EnemyClothing.SelectedIndex = 0;
        }

        private void SetupBattleTimer()
        {
            battleTimer = new DispatcherTimer();
            battleTimer.Interval = TimeSpan.FromSeconds(1);
            battleTimer.Tick += BattleTimer_Tick;
        }

        private void BattleTimer_Tick(object sender, EventArgs e)
        {
            if (isBattleActive && hero != null && enemy != null)
            {
                UpdateHealthBars();
            }
        }

        private void InitializeDefaultImages()
        {
            CreateDefaultCharacterVisual(HeroImage, Colors.Blue);
            CreateDefaultCharacterVisual(EnemyImage, Colors.Red);
        }

        private void CreateDefaultCharacterVisual(Image image, Color color)
        {
            var visual = new Rectangle
            {
                Width = 200,
                Height = 300,
                Fill = new SolidColorBrush(color),
                Stroke = new SolidColorBrush(Colors.White),
                StrokeThickness = 2
            };

            var renderBitmap = new RenderTargetBitmap(200, 300, 96, 96, PixelFormats.Pbgra32);
            renderBitmap.Render(visual);
            image.Source = renderBitmap;
        }

        private void CreateHero_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var builder = new HeroBuilder()
                    .SetHeight(int.Parse(HeroHeight.Text))
                    .SetPhysique(((ComboBoxItem)HeroPhysique.SelectedItem).Content.ToString())
                    .SetHairColor(((ComboBoxItem)HeroHairColor.SelectedItem).Content.ToString())
                    .SetEyeColor(((ComboBoxItem)HeroEyeColor.SelectedItem).Content.ToString())
                    .SetClothing(((ComboBoxItem)HeroClothing.SelectedItem).Content.ToString())
                    .SetBaseStats(15, 12, 10, 14)
                    .SetLevel(1)
                    .AddAbility("Базова атака")
                    .AddAbility("Захист")
                    .AddPassiveSkill("Воля героя");

                hero = builder.Build();
                hero.CharacterClass = ((ComboBoxItem)HeroClass.SelectedItem).Content.ToString();
                hero.WeaponType = ((ComboBoxItem)HeroWeapon.SelectedItem).Content.ToString();
                hero.Attack = int.Parse(HeroAttack.Text);
                hero.Defense = int.Parse(HeroDefense.Text);

                UpdateCharacterVisual(HeroImage, hero);
                UpdateHeroInfo();
                UpdateHealthBars();

                AddBattleLog("Героя успішно створено!");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Помилка створення героя: {ex.Message}", "Помилка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void CreateEnemy_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var builder = new EnemyBuilder()
                    .SetHeight(int.Parse(EnemyHeight.Text))
                    .SetPhysique(((ComboBoxItem)EnemyPhysique.SelectedItem).Content.ToString())
                    .SetHairColor(((ComboBoxItem)EnemyHairColor.SelectedItem).Content.ToString())
                    .SetEyeColor(((ComboBoxItem)EnemyEyeColor.SelectedItem).Content.ToString())
                    .SetClothing(((ComboBoxItem)EnemyClothing.SelectedItem).Content.ToString())
                    .SetBaseStats(14, 13, 12, 15)
                    .SetLevel(1)
                    .AddAbility("Темний удар")
                    .AddAbility("Тіньовий захист")
                    .AddPassiveSkill("Темна аура");

                enemy = builder.Build();
                enemy.CharacterClass = ((ComboBoxItem)EnemyClass.SelectedItem).Content.ToString();
                enemy.WeaponType = ((ComboBoxItem)EnemyWeapon.SelectedItem).Content.ToString();
                enemy.Attack = int.Parse(EnemyAttack.Text);
                enemy.Defense = int.Parse(EnemyDefense.Text);

                UpdateCharacterVisual(EnemyImage, enemy);
                UpdateEnemyInfo();
                UpdateHealthBars();
                AddBattleLog("Ворога успішно створено!");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Помилка створення ворога: {ex.Message}", "Помилка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        private void UpdateCharacterVisual(Image image, Character character)
        {
            var visual = new StackPanel();

            var characterRect = new Rectangle
            {
                Width = 200,
                Height = 300,
                Fill = character.IsHero ? new SolidColorBrush(Colors.Blue) : new SolidColorBrush(Colors.Red),
                Stroke = new SolidColorBrush(Colors.White),
                StrokeThickness = 2
            };

            var characterInfo = new TextBlock
            {
                Text = $"{character.CharacterClass}\n{character.WeaponType}",
                Foreground = new SolidColorBrush(Colors.White),
                TextAlignment = TextAlignment.Center,
                Margin = new Thickness(0, 10, 0, 0)
            };

            visual.Children.Add(characterRect);
            visual.Children.Add(characterInfo);

            var renderBitmap = new RenderTargetBitmap(200, 350, 96, 96, PixelFormats.Pbgra32);
            visual.Measure(new Size(200, 350));
            visual.Arrange(new Rect(0, 0, 200, 350));
            renderBitmap.Render(visual);
            image.Source = renderBitmap;
        }

        private void UpdateHeroInfo()
        {
            if (hero != null)
            {
                HeroInfo.Text = hero.ToString();
            }
        }

        private void UpdateEnemyInfo()
        {
            if (enemy != null)
            {
                EnemyInfo.Text = enemy.ToString();
            }
        }

        private void UpdateHealthBars()
        {
            if (hero != null)
            {
                HeroHealthBar.Value = (hero.Health / (double)hero.MaxHealth) * 100;
                HeroHealthText.Text = $"HP: {hero.Health}/{hero.MaxHealth}";
            }

            if (enemy != null)
            {
                EnemyHealthBar.Value = (enemy.Health / (double)enemy.MaxHealth) * 100;
                EnemyHealthText.Text = $"HP: {enemy.Health}/{enemy.MaxHealth}";
            }
        }

        private void StartBattle_Click(object sender, RoutedEventArgs e)
        {
            if (hero == null || enemy == null)
            {
                MessageBox.Show("Спочатку створіть героя та ворога!", "Помилка", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            if (!isBattleActive)
            {
                isBattleActive = true;
                StartBattle.Content = "Завершити бій";
                AttackButton.IsEnabled = true;
                DefendButton.IsEnabled = true;
                AddBattleLog("Бій розпочато! Оберіть свою дію!");
            }
            else
            {
                isBattleActive = false;
                StartBattle.Content = "Почати бій";
                AttackButton.IsEnabled = false;
                DefendButton.IsEnabled = false;
                AddBattleLog("Бій завершено!");
            }
        }

        private void Attack_Click(object sender, RoutedEventArgs e)
        {
            if (!isBattleActive) return;

            ProcessAttack(hero, enemy, true);

            if (enemy.Health <= 0)
            {
                EndBattle(true);
                return;
            }

            // Ворог контратакує
            ProcessEnemyTurn();
        }

        private void Defend_Click(object sender, RoutedEventArgs e)
        {
            if (!isBattleActive) return;

            isDefending = true;
            AddBattleLog("🛡️ Герой приймає захисну стійку!");

            // Невелика контратака під час захисту
            int counterDamage = (int)(hero.Attack * DEFENSE_COUNTER_DAMAGE);
            enemy.Health = Math.Max(0, enemy.Health - counterDamage);
            AddBattleLog($"↩️ Герой завдає {counterDamage} одиниць шкоди контратакою!");

            // Ворог атакує по захищеному герою
            ProcessEnemyTurn();

            isDefending = false;
            UpdateHealthBars();
        }

        private void ProcessEnemyTurn()
        {
            // Невеличка затримка перед ходом ворога
            AddBattleLog("Ворог готується до атаки...");

            // Ворог атакує
            ProcessAttack(enemy, hero, false);

            // Перевірка чи герой переможений
            if (hero.Health <= 0)
            {
                EndBattle(false);
                return;
            }
        }

        private void ProcessAttack(Character attacker, Character defender, bool isHeroAttacking)
        {
            var storyBuilder = new StringBuilder();
            var damage = CalculateDamage(attacker, defender);

            // Якщо герой захищається, зменшуємо отриманий урон
            if (!isHeroAttacking && isDefending)
            {
                damage = (int)(damage * DEFENSE_DAMAGE_REDUCTION);
                storyBuilder.AppendLine("🛡️ Захист зменшує отриманий урон!");
            }

            // Перевірка ухилення
            if (IsDodged(defender))
            {
                storyBuilder.AppendLine($"🌟 {(isHeroAttacking ? "Ворог спритно ухилився" : "Герой майстерно ухилився")} від атаки!");
                ShowDodgeAnimation(isHeroAttacking);
                AddBattleLog(storyBuilder.ToString());
                return;
            }

            // Перевірка критичного удару
            bool isCritical = IsCriticalHit(attacker);
            if (isCritical)
            {
                damage = (int)(damage * 1.5);
                storyBuilder.AppendLine($"⚡ КРИТИЧНИЙ УДАР! {(isHeroAttacking ? "Герой" : "Ворог")} завдає приголомшливих {damage} одиниць шкоди!");
                ShowCriticalHitAnimation(isHeroAttacking);
            }
            else
            {
                storyBuilder.AppendLine($"⚔️ {(isHeroAttacking ? "Герой" : "Ворог")} завдає {damage} одиниць шкоди");
            }

            // Застосування шкоди з анімацією
            ApplyDamageWithAnimation(defender, damage, isHeroAttacking);

            // Перевірка на нічию після нанесення шкоди
            if (hero.Health <= 0 && enemy.Health <= 0)
            {
                AddBattleLog(storyBuilder.ToString());
                EndBattle(null); // null означає нічию
                return;
            }

            if (attacker.IsHero && hero.Health < hero.MaxHealth * 0.3)
            {
                storyBuilder.AppendLine("🔥 Активовано бойовий дух! Атака героя посилена!");
                ShowBuffAnimation(true);
            }

            if (!attacker.IsHero && enemy.Health < enemy.MaxHealth * 0.3)
            {
                storyBuilder.AppendLine("🌑 Темна сила пробуджується! Ворог стає сильнішим!");
                ShowBuffAnimation(false);
            }

            AddBattleLog(storyBuilder.ToString());
            UpdateHealthBars();

            // Перевірка на перемогу/поразку
            if (enemy.Health <= 0)
            {
                EndBattle(true);
            }
            else if (hero.Health <= 0)
            {
                EndBattle(false);
            }
        }

        private void EndBattle(bool? heroWon)
        {
            isBattleActive = false;
            battleTimer.Stop();
            StartBattle.Content = "Почати бій";
            AttackButton.IsEnabled = false;
            DefendButton.IsEnabled = false;

            string result;
            if (heroWon == null)
            {
                result = "Нічия! Обидва бійці полягли в бою!";
            }
            else
            {
                result = heroWon.Value ? "Герой переміг!" : "Ворог переміг!";
            }

            AddBattleLog(result);
            MessageBox.Show(result, "Кінець бою", MessageBoxButton.OK, MessageBoxImage.Information);

            if (heroWon == true) // Досвід нараховується тільки при перемозі героя
            {
                hero.Experience += 50;
                        if (hero.Experience >= hero.ExperienceToNextLevel)
                {
                    hero.LevelUp();
                    AddBattleLog($"Герой досяг {hero.Level} рівня!");
                    UpdateHeroInfo();
                }
            }
        }

        private async void ShowDodgeAnimation(bool isHeroAttacking)
        {
            var target = isHeroAttacking ? EnemyImage : HeroImage;
            var animation = new DoubleAnimation
            {
                From = 1.0,
                To = 0.3,
                Duration = TimeSpan.FromMilliseconds(200),
                AutoReverse = true
            };
            target.BeginAnimation(UIElement.OpacityProperty, animation);
        }

        private async void ShowCriticalHitAnimation(bool isHeroAttacking)
        {
            var target = isHeroAttacking ? EnemyImage : HeroImage;
            var originalColor = isHeroAttacking ? Colors.Red : Colors.Blue;

            var colorAnimation = new ColorAnimation
            {
                From = originalColor,
                To = Colors.Yellow,
                Duration = TimeSpan.FromMilliseconds(300),
                AutoReverse = true
            };

            var effect = target.Effect as DropShadowEffect;
            effect?.BeginAnimation(DropShadowEffect.ColorProperty, colorAnimation);
        }

        private async void ApplyDamageWithAnimation(Character defender, int damage, bool isHeroAttacking)
        {
            var healthBar = isHeroAttacking ? EnemyHealthBar : HeroHealthBar;
            var currentHealth = defender.Health;
            defender.Health = Math.Max(0, currentHealth - damage);

            var animation = new DoubleAnimation
            {
                From = (currentHealth / (double)defender.MaxHealth) * 100,
                To = (defender.Health / (double)defender.MaxHealth) * 100,
                Duration = TimeSpan.FromMilliseconds(500)
            };

            animation.Completed += (s, e) =>
            {
                if (isHeroAttacking)
                {
                    EnemyHealthText.Text = $"HP: {defender.Health}/{defender.MaxHealth}";
                }
                else
                {
                    HeroHealthText.Text = $"HP: {defender.Health}/{defender.MaxHealth}";
                }
            };

            healthBar.BeginAnimation(ProgressBar.ValueProperty, animation);
        }

        private void ShowBuffAnimation(bool isHero)
        {
            var effectsPanel = isHero ? HeroEffects : EnemyEffects;
            var buffIcon = new Image
            {
                Source = new BitmapImage(new Uri("D:\\2 Курс\\Конструювання програмного забезпечення\\lab-2\\task-5\\images\\buff.jpg", UriKind.Relative)),
                Width = 24,
                Height = 24,
                Margin = new Thickness(2)
            };

            effectsPanel.Children.Add(buffIcon);

            var fadeAnimation = new DoubleAnimation
            {
                From = 1.0,
                To = 0.0,
                Duration = TimeSpan.FromSeconds(3)
            };
            fadeAnimation.Completed += (s, e) => effectsPanel.Children.Remove(buffIcon);

            buffIcon.BeginAnimation(UIElement.OpacityProperty, fadeAnimation);
        }

        private int CalculateDamage(Character attacker, Character defender)
        {
            return Math.Max(1, attacker.Attack - (defender.Defense / 2));
        }

        private bool IsCriticalHit(Character attacker)
        {
            return random.NextDouble() * 100 <= attacker.CriticalChance;
        }

        private bool IsDodged(Character defender)
        {
            return random.NextDouble() * 100 <= defender.DodgeChance;
        }

        private void EndBattle(bool heroWon)
        {
            isBattleActive = false;
            battleTimer.Stop();
            StartBattle.Content = "Почати бій";

            string result = heroWon ? "Герой переміг!" : "Ворог переміг!";
            AddBattleLog(result);
            MessageBox.Show(result, "Кінець бою", MessageBoxButton.OK, MessageBoxImage.Information);

            if (heroWon)
            {
                hero.Experience += 50;
                if (hero.Experience >= hero.ExperienceToNextLevel)
                {
                    hero.LevelUp();
                    AddBattleLog($"Герой досяг {hero.Level} рівня!");
                    UpdateHeroInfo();
                }
            }
        }

        private void AddBattleLog(string message)
        {
            battleLog.Insert(0, $"[{DateTime.Now:HH:mm:ss}] {message}\n");
            BattleLog.Text = battleLog.ToString();

            var animation = new DoubleAnimation
            {
                From = 0,
                To = 1,
                Duration = TimeSpan.FromMilliseconds(300)
            };
            BattleLog.BeginAnimation(UIElement.OpacityProperty, animation);
        }

        private void ResetBattle_Click(object sender, RoutedEventArgs e)
        {
            if (hero != null) hero.Health = hero.MaxHealth;
            if (enemy != null) enemy.Health = enemy.MaxHealth;

            isBattleActive = false;
            isDefending = false;
            StartBattle.Content = "Почати бій";
            AttackButton.IsEnabled = false;
            DefendButton.IsEnabled = false;
            battleLog.Clear();
            BattleLog.Text = "";

            UpdateHealthBars();
            AddBattleLog("Бій скинуто!");
        }

        private void ClearBattleLog_Click(object sender, RoutedEventArgs e)
        {
            battleLog.Clear();
            BattleLog.Text = "";
        }
    }
}