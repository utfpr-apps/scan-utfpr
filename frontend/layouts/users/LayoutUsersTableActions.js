import {
  Menu,
  MenuButton,
  MenuList,
  MenuItem,
  IconButton,
} from "@chakra-ui/react";

import { BiDotsVerticalRounded } from "react-icons/bi";
import LayoutUsersTableActionsRemoveUser from "./LayoutUsersTableActionsRemoveUser";

const LayoutUsersTableActions = ({ user }) => (
  <Menu>
    <MenuButton
      as={IconButton}
      aria-label="Options"
      icon={<BiDotsVerticalRounded />}
      variant="ghost"
    />

    <MenuList>
      <LayoutUsersTableActionsRemoveUser user={user} />
    </MenuList>
  </Menu>
);

export default LayoutUsersTableActions;
