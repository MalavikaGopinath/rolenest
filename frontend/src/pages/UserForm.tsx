import { useState, useEffect } from "react";
import { useNavigate, useParams } from "react-router-dom";
import { createUser, getUserById } from "../services/UserService";
import type { UserCreateDto } from "../types/User";

const UserForm = () => {
  const navigate = useNavigate();
  const { id } = useParams();
  const [user, setUser] = useState<UserCreateDto>({
    firstName: "",
    lastName: "",
    email: "",
    role: "User",
  });

  const isEditMode = Boolean(id);

  useEffect(() => {
    if (isEditMode && id) {
      const fetchUser = async () => {
        const data = await getUserById(id);
        setUser({
          firstName: data.firstName,
          lastName: data.lastName,
          email: data.email,
          role: data.role,
        });
      };

      fetchUser();
    }
  }, [id, isEditMode]);

  const handleChange = (
    e: React.ChangeEvent<HTMLInputElement | HTMLSelectElement>
  ) => {
    setUser({ ...user, [e.target.name]: e.target.value });
  };

  const handleSubmit = async (e: React.FormEvent) => {
    e.preventDefault();
    try {
      await createUser(user);
      navigate("/");
    } catch (error) {
      console.error("Error saving user:", error);
    }
  };

  return (
    <form onSubmit={handleSubmit}>
      <h2>{isEditMode ? "Edit User" : "Create User"}</h2>
      <input
        name="firstName"
        placeholder="First Name"
        value={user.firstName}
        onChange={handleChange}
        required
      />
      <input
        name="lastName"
        placeholder="Last Name"
        value={user.lastName}
        onChange={handleChange}
        required
      />
      <input
        name="email"
        placeholder="Email"
        type="email"
        value={user.email}
        onChange={handleChange}
        required
      />
      <select name="role" value={user.role} onChange={handleChange}>
        <option value="User">User</option>
        <option value="Admin">Admin</option>
      </select>
      <button type="submit">{isEditMode ? "Update" : "Save"}</button>
    </form>
  );
};

export default UserForm;
