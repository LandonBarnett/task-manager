import { useForm } from "react-hook-form";
import { yupResolver } from "@hookform/resolvers/yup";
import * as yup from "yup";

// Yup schema defines *client-side validation rules*
const schema = yup.object({
    title: yup.string().required("Title is required"),
    description: yup.string().max(500, "Too long"),
    dueDate: yup.date().required("Due date required").min(new Date(), "Must be in future"),
    owner: yup.string().max(500, "Too long"),
});

export default function TaskForm(){
    //Initialize form with validation
    const { register, handleSubmit, formState: { errors } } = useForm({
        resolver: yupResolver(schema)
    });

    //Called when the form is valid and submitted
    const onSubmit = async (data:any) => {

        //Sends POST request to ASP.NET API
        await fetch("/api/tasks", {
            method: "POST",
            headers: { "Content-Type": "application/json" },
            body: JSON.stringify(data)
        });
        alert("Task created!");
    };

    return (
        <form onSubmit={handleSubmit(onSubmit)}>
            <input {...register("title")} placeholder="Title"  />
            {errors.description && <span>{errors.description.message}</span>}

            <input {...register("description")} placeholder="Description" />
            {errors.description && <span>{errors.description.message}</span>}

            <input {...register("owner")} placeholder="Owner" />
            {errors.description && <span>{errors.description.message}</span>}

           <input type={"date"} {...register("dueDate")} />
            {errors.dueDate && <span>{errors.dueDate.message}</span>}

            <button type="submit">Create Task</button>
        </form>
    )
}