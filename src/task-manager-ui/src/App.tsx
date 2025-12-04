import TaskList from "./components/TaskList";
import TaskForm from "./components/TaskForm";

export default function App() {
    return (
        <div className="min-h-screen bg-gray-100 flex flex-col">
            {/* Header */}
            <header className="bg-white shadow-sm p-4">
                <h1 className="text-2xl font-semibold text-gray-800 text-center">
                    Task Manager
                </h1>
            </header>

            {/* Main Content */}
            <main className="flex flex-col md:flex-row gap-6 p-6 max-w-6xl mx-auto w-full">
                {/* Left: Task List */}
                <div className="flex-1 bg-white rounded-2xl shadow p-6">
                    <h2 className="text-xl font-semibold mb-4">Your Tasks</h2>
                    <TaskList />
                </div>

                {/* Right: Create Task Form */}
                <div className="w-full md:w-96 bg-white rounded-2xl shadow p-6">
                    <h2 className="text-xl font-semibold mb-4">Add Task</h2>
                    <TaskForm />
                </div>
            </main>
        </div>
    );
}
