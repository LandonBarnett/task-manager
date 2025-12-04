import { useEffect, useState } from "react";

type TaskDto = {
    id: number;
    title: string;
    description?: string;
    owner: string;
    dueDate: string;
};

export default function TaskList() {
    const [tasks, setTasks] = useState<TaskDto[]>([]);

    useEffect(() => {
        fetch("/api/tasks")  //Call .NET backend
            .then(r => r.json())  //parse JSON
            .then(setTasks);  //Update state
    }, []);

    return (
        <div>
            <h2>Tasks</h2>
            <ul>
                {tasks.map(t => (
                    <li key={t.owner}>
                        <strong>{t.title}</strong> - {t.description} - {t.dueDate}
                    </li>
                ))}
            </ul>
        </div>
    )
}