import { useEffect, useState } from "react";
import { useParams } from "react-router-dom";
import { getUserById } from "../services/UserService";

interface User {
  id: string;
  firstName: string;
  lastName: string;
  email: string;
  role: string;
}

const UserDetails = () => {
  const { id } = useParams<{ id: string }>();
  const [user, setUser] = useState<User | null>(null);

  useEffect(() => {
    if (id) {
      getUserById(id).then(setUser);
    }
  }, [id]);

  if (!user) return <div>Loading...</div>;

  return (
    <div>
      <h2>{user.firstName} {user.lastName}</h2>
      <p>Email: {user.email}</p>
      <p>Role: {user.role}</p>
    </div>
  );
};

export default UserDetails;
