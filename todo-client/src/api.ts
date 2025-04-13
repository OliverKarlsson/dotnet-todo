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
