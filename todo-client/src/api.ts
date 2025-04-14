const baseUrl = "http://localhost:5000";

export const getAllTodos = async () => {
  return await (await fetch(`${baseUrl}/todos`)).json();
};

export const getActiveTodos = async () => {
  return await (await fetch(`${baseUrl}/todos/active`)).json();
};

export const getCompletedTodos = async () => {
  return await (await fetch(`${baseUrl}/todos/completed`)).json();
};

export const postCompleteTodo = async (id: string) => {
  await (
    await fetch(`${baseUrl}/todos/${id}/complete`, { method: "post" })
  ).json();
};

export const postUndoTodo = async (id: string) => {
  await (
    await fetch(`${baseUrl}/todos/${id}/undo-complete`, { method: "post" })
  ).json();
};

export const postCreateTodo = async (name: string) => {
  await (
    await fetch(`${baseUrl}/todos/create`, {
      method: "post",
      headers: {
        "Content-Type": "application/json",
      },
      body: JSON.stringify({ name }),
    })
  ).json();
};
