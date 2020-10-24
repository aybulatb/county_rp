import { Group } from 'AdminPanel/types';
import { getGroupsFilterBy } from 'AdminPanel/services';
import { handlerFetchError } from 'AdminPanel/utils/handlerFactory';


export const createGroupsSearchStore = () => ({
  searchResult: [] as Group[],
  maxPage: 1,
  currentPage: 1,

  goToNextPage() {
    if (this.currentPage < this.maxPage) {
      this.currentPage++;
    }
  },

  goToPrevPage() {
    if (this.currentPage > 1) {
      this.currentPage--;
    }
  },

  async searchGroups(groupId: string = '', groupName: string = '') {
    try {
      const response = await getGroupsFilterBy(this.currentPage, groupId, groupName);

      this.searchResult = response.items;
      this.maxPage = response.maxPage;
    } catch (error) {
      handlerFetchError(error);
    }
  }
});


export type TGroupsSearchStore = ReturnType<typeof createGroupsSearchStore>