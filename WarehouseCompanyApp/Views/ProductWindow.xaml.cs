using System;
using System.Data.SqlClient;
using System.Windows;
using WarehouseCompanyApp.Controllers;

namespace WarehouseCompanyApp.Views
{
    public partial class ProductWindow : Window
    {
        private ProductController productController = new ProductController();

        public ProductWindow()
        {
            InitializeComponent();
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                var products = productController.GetAllProducts();
                MessageBox.Show("Товаров в приложении: " + products.Count);
                dataGridProducts.ItemsSource = products;

                cmbCategory.Items.Clear();
                cmbCategory.Items.Add("Электроника");
                cmbCategory.Items.Add("Бытовая техника");
                cmbCategory.Items.Add("Офисная техника");
                cmbCategory.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при загрузке окна: " + ex.Message, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var selectedProduct = dataGridProducts.SelectedItem as WarehouseCompanyApp.Models.Product;
                if (selectedProduct == null)
                {
                    MessageBox.Show("Выберите товар для редактирования!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
                }

                string name = txtName.Text;
                string description = txtDescription.Text;
                string category = cmbCategory.SelectedItem?.ToString() ?? "";
                decimal price;
                if (!decimal.TryParse(txtPrice.Text, out price))
                {
                    MessageBox.Show("Введите корректную цену!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }

                selectedProduct.Name = name;
                selectedProduct.Description = description;
                selectedProduct.Category = category;
                selectedProduct.Price = price;

                productController.UpdateProduct(selectedProduct);
                dataGridProducts.ItemsSource = productController.GetAllProducts();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при редактировании товара: " + ex.Message, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtName.Text))
            {
                MessageBox.Show("Название товара не может быть пустым!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            decimal price;
            if (!decimal.TryParse(txtPrice.Text, out price))
            {
                MessageBox.Show("Введите корректную цену!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            try
            {
                productController.AddProduct(new WarehouseCompanyApp.Models.Product
                {
                    Name = txtName.Text,
                    Description = txtDescription.Text,
                    Category = cmbCategory.SelectedItem?.ToString() ?? "",
                    Price = price
                });

                dataGridProducts.ItemsSource = productController.GetAllProducts();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при добавлении товара: " + ex.Message, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var selectedProduct = dataGridProducts.SelectedItem as WarehouseCompanyApp.Models.Product;
                if (selectedProduct == null)
                {
                    MessageBox.Show("Выберите товар для удаления!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
                }

                var result = MessageBox.Show("Вы уверены, что хотите удалить товар?", "Подтверждение", MessageBoxButton.YesNo, MessageBoxImage.Question);
                if (result == MessageBoxResult.Yes)
                {
                    productController.DeleteProduct(selectedProduct.ProductID);
                    dataGridProducts.ItemsSource = productController.GetAllProducts();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при удалении товара: " + ex.Message, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void dataGridProducts_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            try
            {
                var selectedProduct = dataGridProducts.SelectedItem as WarehouseCompanyApp.Models.Product;
                if (selectedProduct != null)
                {
                    txtName.Text = selectedProduct.Name;
                    txtDescription.Text = selectedProduct.Description;
                    cmbCategory.SelectedItem = selectedProduct.Category;
                    txtPrice.Text = selectedProduct.Price.ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при выборе товара: " + ex.Message, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}