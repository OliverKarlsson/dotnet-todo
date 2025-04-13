import "./style.css";
import { Card } from "./Card.ts";
import {
  ACTIVE_TODOS_CONTENT_ID,
  ALL_TODOS_CONTENT_ID,
  COMPLETED_TODOS_CONTENT_ID,
} from "./constants.ts";
import { fetchTodos } from "./fetchTodos.ts";

document.querySelector<HTMLDivElement>("#app")!.innerHTML = `
  <div>
    <h1>Todos</h1>
    ${Card({ title: "All todos", contentId: ALL_TODOS_CONTENT_ID })}
    ${Card({ title: "Active todos", contentId: ACTIVE_TODOS_CONTENT_ID })}
    ${Card({ title: "Completed todos", contentId: COMPLETED_TODOS_CONTENT_ID })}
  </div>
`;

fetchTodos();
