import { postCompleteTodo, postUndoTodo } from "./api";

export type TodoItemProps = {
  id: string;
  name: string;
  creationDate: string;
  status: "Completed" | "Active";
};

type ActionButtonProps = {
  id: string;
};

const undoButton = ({ id }: ActionButtonProps) =>
  `<button onclick="undoTodo('${id}')">Undo</button>`;

const completeButton = ({ id }: ActionButtonProps) =>
  `<button onclick="completeTodo('${id}')">Complete</button>`;

export const TodoItem = ({ name, creationDate, status, id }: TodoItemProps) =>
  `<li>
<span class="todo-name">${name}</span>
<span class="todo-creation-date">${creationDate}</span>
<span>${status === "Active" ? `🔳` : `✅`}</span>
${status === "Active" ? completeButton({ id }) : undoButton({ id })}
</li>`;

//@ts-ignore
window.undoTodo = (id) => {
  postUndoTodo(id);
  window.location.reload();
};

//@ts-ignore
window.completeTodo = (id) => {
  postCompleteTodo(id);
  window.location.reload();
};
