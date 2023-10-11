using PokemonReviewApp.Data;
using PokemonReviewApp.Interfaces;
using PokemonReviewApp.Models;

namespace PokemonReviewApp.Repositries
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly DataContext _context;

        public CategoryRepository(DataContext context)
        {
            _context = context;
        }
        public bool CategoriesExists(int id)
        {
            return _context.Categories.Any(c => c.CategoryId == id);
        }

        public bool CreateCategory(Category category)
        {
            _context.Add(category);// track
            _context.SaveChanges();//save
            return true;
        }

        public bool DeleteCategory(Category category)
        {
           _context.Remove(category);
            _context.SaveChanges();
            return true;
        }

        public ICollection<Category> GetCategories()
        {
            return _context.Categories.ToList();
        }

        public Category GetCategory(int id)
        {
            return _context.Categories.Where(e => e.CategoryId == id).FirstOrDefault();
        }

        public ICollection<Pokemon> GetPokemonByCategory(int categoryId)
        {
           return _context.PokemonCategories.Where(e => e.CategoryId == categoryId).Select(c => c.Pokemon).ToList();
        }

        public bool UpdateCategory(Category category)
        {
           _context.Update(category);
            _context.SaveChanges();
            return true;
        }   
    }
}
