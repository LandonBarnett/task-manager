import TaskForm from "./components/TaskForm";
import TaskList from "./components/TaskList";

export default function App() {
    return (
        <div style={{ maxWidth:600, margin: "0 auto", padding:20 }}>
            <h1>Task Manager</h1>

            <TaskForm />

                <hr />


            <TaskList />
        </div>
    );
}