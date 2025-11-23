using _20251118_ToDoApp_1.Models;
using Microsoft.AspNetCore.Mvc;
using _20251118_ToDoApp_1.Data;
using Microsoft.EntityFrameworkCore;

namespace _20251118_ToDoApp_1.Controllers
{
    public class TodoController : Controller
    {
        private readonly AppDbContext _context;
        public TodoController(AppDbContext context)
        {
            _context = context;
        }

        //一覧
        public async Task<IActionResult> Index()
        {
            var todos = await _context.Todos.ToListAsync();
            return View(todos);
        }

        //追加画面
        public IActionResult Create()
        {
            return View();
        }

        //追加処理
        [HttpPost]
        public async Task<IActionResult> Create(Todo todo)
        {
            _context.Add(todo);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        //完了状態の切り替え
        public async Task<IActionResult> Toggle(int id)
        {
            var todo = await _context.Todos.FindAsync(id);
            if (todo != null)
            {
                todo.IsDone = !todo.IsDone;
                await _context.SaveChangesAsync();
            }
            return RedirectToAction(nameof(Index));
        }

        //削除
        public async Task<IActionResult> Delete(int id)
        {
            var todo = await _context.Todos.FindAsync(id);
            if (todo != null)
            {
                _context.Todos.Remove(todo);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction(nameof(Index));
        }
    }
    
}
