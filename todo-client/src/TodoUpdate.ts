type Props = {
  id: number;
  name: string;
  status: string;
  eventTimeStamp: string;
};

export const TodoUpdate = ({ id, name, status, eventTimeStamp }: Props) => `
<div>
<span><strong>Id: ${id}</strong> name: ${name} <strong>Status: ${status}</strong> time stamp: ${eventTimeStamp}</span>
</div>
`;
