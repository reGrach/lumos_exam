<template>
  <v-card :color="colorQuestion" dark>
    <div>
      <v-alert v-model="alert" dense outlined type="error" dismissible>
        <strong>{{error}}</strong>
      </v-alert>
    </div>
    <v-badge color="green" :content="number" left :offset-x="15" :offset-y="15">
      <v-card-subtitle class="text-justify">{{quest.text}}</v-card-subtitle>
    </v-badge>

    <v-card-actions>
      <v-btn icon @click="updateStatusQuest(quest.id, quest.isClear, statusEnum.isClear)">
        <v-icon v-if="getClear" color="green">mdi-emoticon-outline</v-icon>
        <v-icon v-else color="red">mdi-emoticon-frown-outline</v-icon>
      </v-btn>

      <v-btn icon @click="updateStatusQuest(quest.id, quest.isWritten, statusEnum.isWritten)">
        <v-icon :color="getWritten">mdi-pencil</v-icon>
      </v-btn>

      <v-btn icon @click="updateStatusQuest(quest.id, quest.isLearned, statusEnum.isLearned)">
        <v-icon :color="getLearned">mdi-thumb-up</v-icon>
      </v-btn>

      <v-spacer></v-spacer>

      <v-btn icon @click="updateStatusQuest(quest.id, quest.isDeferred, statusEnum.isDeffered)">
        <v-icon :color="getDeferred">mdi-update</v-icon>
      </v-btn>
    </v-card-actions>
  </v-card>
</template>

<script>
import { updateStatus } from "@/axios";
export default {
  props: {
    quest: Object,
    number: Number
  },

  data: () => ({
    alert: false,
    error: null,
    colorQuestion: "#006064",
    statusEnum: Object.freeze({
      isClear: 1,
      isWritten: 2,
      isLearned: 3,
      isDeffered: 4
    })
  }),

  computed: {
    getClear() {
      return this.quest.isClear ? true : false;
    },
    getWritten() {
      return this.quest.isWritten ? "green" : "red";
    },
    getLearned() {
      return this.quest.isLearned ? "green" : "red";
    },
    getDeferred() {
      return this.quest.isDeffered ? "yellow" : "white";
    }
  },

  methods: {
    updateStatusQuest(id, val, status) {
      updateStatus(id, !val, status)
        .then(() => {
          switch (status) {
            case this.statusEnum.isClear:
              this.quest.isClear = !this.quest.isClear;
              break;
            case this.statusEnum.isWritten:
              this.quest.isWritten = !this.quest.isWritten;
              break;
            case this.statusEnum.isLearned:
              this.quest.isLearned = !this.quest.isLearned;
              break;
            case this.statusEnum.isDeffered:
              this.quest.isDeffered = !this.quest.isDeffered;
              break;
          }
        })
        .catch(() => {
          this.error = "Не получилось...( Обратись к Гере.";
        });
    }
  }
};
</script>