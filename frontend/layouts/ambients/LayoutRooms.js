import Container from "components/Container";
import PageLayout from "components/PageLayout";

import LayoutRoomsHeader from "./LayoutRoomsHeader";
import LayoutAmbientsTable from "./LayoutAmbientsTable";

const LayoutRooms = () => (
  <PageLayout pageTitle="Salas e Ambientes">
    <Container my="25px" direction="column" flex={1} p="32px">
      <LayoutRoomsHeader />

      <LayoutAmbientsTable />
    </Container>
  </PageLayout>
);

export default LayoutRooms;
