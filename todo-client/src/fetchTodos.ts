import {
  getActiveTodos,
  getAllTodos,
  getCompletedTodos,
  getTodosUpdates,
} from "./api";
import {
  ACTIVE_TODOS_CONTENT_ID,
  ALL_TODOS_CONTENT_ID,
  COMPLETED_TODOS_CONTENT_ID,
  TODOS_UPDATES_CONTENT_ID,
} from "./constants";
import { Loader } from "./Loader";
import { TodoItem, TodoItemProps } from "./TodoItem";
import { TodosList } from "./TodosList";
import { TodoUpdate } from "./TodoUpdate";

const makeTodos = (items: TodoItemProps[]) =>
  items.reduce((acc, item) => {
    return acc + TodoItem(item);
  }, "");

const renderFetchedTodo = async (
  fetcher: () => Promise<TodoItemProps[]>,
  contentId: string
) => {
  const todosContentRoot = document.getElementById(contentId);

  if (todosContentRoot) {
    todosContentRoot.innerHTML = Loader();

    const todos = await fetcher();

    todosContentRoot.innerHTML = TodosList({ content: makeTodos(todos) });
  }
};

const renderFetchedTodoUpdates = async () => {
  const updatesContentRoot = document.getElementById(TODOS_UPDATES_CONTENT_ID);

  if (updatesContentRoot) {
    updatesContentRoot.innerHTML = Loader();

    const updates = (await getTodosUpdates()) as any[];

    updatesContentRoot.innerHTML = updates.reduce((acc, update) => {
      return acc + TodoUpdate(update);
    }, "");
  }
};

export const fetchTodos = async () => {
  await Promise.all([
    renderFetchedTodoUpdates(),
    renderFetchedTodo(getAllTodos, ALL_TODOS_CONTENT_ID),
    renderFetchedTodo(getActiveTodos, ACTIVE_TODOS_CONTENT_ID),
    renderFetchedTodo(getCompletedTodos, COMPLETED_TODOS_CONTENT_ID),
  ]);
};
